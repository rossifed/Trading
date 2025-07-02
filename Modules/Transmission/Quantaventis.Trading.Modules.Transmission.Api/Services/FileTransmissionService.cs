using Microsoft.Extensions.Logging;


using Quantaventis.Trading.Modules.Transmission.Api.Options;
using Quantaventis.Trading.Modules.Transmission.Domain.Exceptions;
using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Repositories;
using Quantaventis.Trading.Modules.Transmission.Domain.Services;

using Quantaventis.Trading.Modules.Transmission.Infrastructure.Services;

namespace Quantaventis.Trading.Modules.Transmission.Api.Services
{
    internal interface IFileTransmissionService
    {
        Task GenerateAndTransmitAllAsync(bool forceEod= false);
        Task GenerateAndTransmitAsync(int transmissionProfileId);
    }
    internal class FileTransmissionService : IFileTransmissionService
    {

        private IFileTransmitter FileTransmitter { get; }
        private IFileGenerationService FileGenerationService { get; }
        private IFileArchiver FileArchiver { get; }
        private IFileEncryptor FileEncryptor { get; }
        private FileTransmissionOptions FileTransmissionOptions { get; }
        private IFileTransmissionRepository FileTransmissionRepository { get; }

        private ILogger<FileTransmissionService> Logger { get; }
        private  ITransmissionProfileRepository TransmissionProfileRepository { get; }
        public FileTransmissionService(FileTransmissionOptions options,
            IFileGenerationService fileGenerationService,
             IFileTransmitter fileTransmitter,
             IFileEncryptor fileEncryptor,
             IFileArchiver fileArchiver,
            ITransmissionProfileRepository transmissionProfileRepository,

            IFileTransmissionRepository fileTransmissionRepository,
            ILogger<FileTransmissionService> logger
            )
        {
            FileTransmissionOptions = options;
            FileGenerationService = fileGenerationService;
            FileEncryptor = fileEncryptor;
            FileTransmitter = fileTransmitter;
            FileArchiver = fileArchiver;
            TransmissionProfileRepository = transmissionProfileRepository;
            FileTransmissionRepository = fileTransmissionRepository;
            Logger = logger;
        }


        public async Task GenerateAndTransmitAllAsync(bool forceEod = false)
        {
            IEnumerable<TransmissionProfile> transmissionProfiles = await TransmissionProfileRepository.GetAllEnabledAsync();
             await GenerateAndTransmitAsync(transmissionProfiles, forceEod);
        }


        public async Task GenerateAndTransmitAsync(IEnumerable<TransmissionProfile> transmissionProfiles, bool forceEod = false)
        {
            foreach (TransmissionProfile transmissionProfile in transmissionProfiles)
            {
                
                    await GenerateAndTransmitAsync(transmissionProfile,  forceEod);
                
            }
        }

        private async Task GenerateAndTransmitAsync(TransmissionProfile transmissionProfile, bool forceEod = false)
        {
            if (transmissionProfile.IsAwaitingEndOfDAy( FileTransmissionOptions.ParseEodTransmissionTimeUtc()) && !forceEod)//dont send eod files before cutoff time
                return;

            IEnumerable<TransmissionFile> generatedFiles = Enumerable.Empty<TransmissionFile>();
            try
            {
                Logger.LogInformation($"Files transmission triggered for TransmissionProfile: {transmissionProfile}");
                Logger.LogInformation($"Generating Files...");
                generatedFiles = await FileGenerationService.GenerateFilesAsync(transmissionProfile.FileGenerationProfiles);
                if (generatedFiles.Any())
                {
                    if (transmissionProfile.EncryptionProfile != null)
                    {
                        Logger.LogInformation($"Encrypting Files...");
                        generatedFiles = await FileEncryptor.EncryptFilesAsync(generatedFiles, transmissionProfile.EncryptionProfile);
                    }
                    Logger.LogInformation($"Tramsitting Files...");

                    if (transmissionProfile.IsFtpTransmissionActive)
                    {
                        FileTransmission fileTransmission = await FileTransmitter.TransmitAsync(transmissionProfile, generatedFiles);


                        Logger.LogInformation($"Archiving Files...");
                        await FileTransmissionRepository.AddAsync(fileTransmission);
                        FileArchiver.ArchiveToSuccessFolder(fileTransmission.TransmittedFiles);
                      
                    }
                }
            }
            catch (FileGenerationException ex)
            {
                Logger.LogError(ex, "An error occured during files generation. Files couldn't be transmitted.");
                FileArchiver.ArchiveToErrorFolder(generatedFiles);
               
            }
            catch (FileEncryptionException ex)
            {
                Logger.LogError(ex, "An error occured during files encrpytion. Files couldn't be transmitted.");
                FileArchiver.ArchiveToErrorFolder(generatedFiles);
              
            }
            catch (FileTransmissionException ex)
            {
                Logger.LogError(ex, "An error occured during files transmission. One or many files couldn't be transmitted.");
                FileArchiver.ArchiveToErrorFolder(generatedFiles);
             
            }
            catch (FileArchivingException ex)
            {
                Logger.LogError(ex, "Error Archiving files. File may be submitted but not archived.");
          
            }
          
        }

        public async Task GenerateAndTransmitAsync(int transmissionProfileId)
        {
            TransmissionProfile? transmissionProfile = await TransmissionProfileRepository.GetByIdAsync(transmissionProfileId);
            if (transmissionProfile == null)
            {
                Logger.LogInformation($"TransmittionProfile with Id {transmissionProfileId} was not funt");
            }
            else
            {
  
                await GenerateAndTransmitAsync(transmissionProfile);
            }
        }
    }
}

