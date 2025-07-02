using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Exceptions;
namespace Quantaventis.Trading.Modules.Transmission.Domain.Services
{
    internal interface IFileTransmitter
    {
        Task<FileTransmission> TransmitAsync(TransmissionProfile transmissionProfile, IEnumerable<TransmissionFile> generatedFiles);
    }
    internal class FileTransmitter : IFileTransmitter
    {

        private IFtpUploader FtpUploader { get; }
        private IEmailSender EmailSender { get; }
        private ILogger<FileTransmitter> Logger { get; }


        public FileTransmitter(
            IFtpUploader ftpUploader,
            IEmailSender emailSender,
            ILogger<FileTransmitter> logger)
        {
            FtpUploader = ftpUploader;
            EmailSender = emailSender;
            Logger = logger;
        }





        public async Task<FileTransmission> TransmitAsync(TransmissionProfile transmissionProfile, IEnumerable<TransmissionFile> generatedFiles)
        {
            bool isFtpTransmitted = false, isEmailTransmitted = false;
            IEnumerable<TransmissionFile> transmittedFiles = Enumerable.Empty<TransmissionFile>();
            try
            {
                if (transmissionProfile.FtpConfiguration != null)
                {

                    FtpUploader.UploadFiles(generatedFiles, transmissionProfile.FtpConfiguration);
                    isFtpTransmitted = true;
                    transmittedFiles = generatedFiles;
                }

                if (transmissionProfile.EmailConfiguration != null)
                {
                    await EmailSender.SendEmailAsync(generatedFiles, transmissionProfile.EmailConfiguration);

                    isEmailTransmitted = true;
                    transmittedFiles = generatedFiles;
                }

                return new FileTransmission(transmissionProfile.Mnemonic,
                transmissionProfile.CounterParty.Name,
                transmissionProfile.ContentType.Mnemonic,
                DateTime.Now,
                isFtpTransmitted,
                isEmailTransmitted,
                transmittedFiles);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error transmitting files for TransmissionProfile {transmissionProfile.Mnemonic}", ex);

                throw new FileTransmissionException(transmissionProfile, ex);
            }
        }


    }
}
