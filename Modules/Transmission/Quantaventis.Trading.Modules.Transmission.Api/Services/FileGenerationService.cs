using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Api.Options;

using Quantaventis.Trading.Modules.Transmission.Domain.Services;

namespace Quantaventis.Trading.Modules.Transmission.Api.Services
{
    internal interface IFileGenerationService{
        Task<IEnumerable<TransmissionFile>> GenerateFilesAsync(IEnumerable<FileGenerationProfile> fileGenerationProfile);

    }
    internal class FileGenerationService: IFileGenerationService
    {
        private IFileNameGenerator FileNameGenerator { get; }
        private IFileContentGenerator FileContentGenerator { get; }
        private IFileWriter FileWriter { get; }
     
        private Folder RootDirectory { get; }

        public FileGenerationService(
            FileGenerationOptions options,
            IFileNameGenerator fileNameGenerator,
            IFileContentGenerator fileContentGenerator,
            IFileWriter fileWriter)
        {
            FileContentGenerator = fileContentGenerator;
            FileWriter = fileWriter;   
            FileNameGenerator = fileNameGenerator;
            RootDirectory = new Folder(options.WorkingFolder);
        }


        public async Task<TransmissionFile> GenerateFileAsync(FileGenerationProfile fileGenerationProfile, FileContent fileContent)
        {

            var timeStamp = DateTime.Now;
            Folder targetFolder = RootDirectory.Combine(fileGenerationProfile.OutputFolder);
            FileName fileName = FileNameGenerator.GenerateFileName(fileGenerationProfile.FileNameGenerationInfo);
            TransmissionFile emptyFile = targetFolder.CreateFile(fileName);

            TransmissionFile fileWithContent = emptyFile.AddContent(fileContent);
            await FileWriter.WriteAsync(fileWithContent);
            return fileWithContent;
        }

 
        public async Task<IEnumerable<TransmissionFile>> GenerateFilesAsync(IEnumerable<FileGenerationProfile> fileGenerationProfiles)
        {
            List<TransmissionFile> files = new List<TransmissionFile>();
            foreach (var profile in fileGenerationProfiles)
            {
                FileContent fileContent = FileContentGenerator.GenerateFileContent(profile.FileContentGenerationInfo);
                if (!fileContent.IsEmpty)
                {
                    TransmissionFile file = await GenerateFileAsync(profile, fileContent);
                    files.Add(file);
                }
            }
            return files;
        }

    }
}
