using Quantaventis.Trading.Modules.Transmission.Domain.Model;


namespace Quantaventis.Trading.Modules.Transmission.Domain.Services
{
    internal interface IFileNameGenerator {
        FileName GenerateFileName(FileNameGenerationInfo fileNameGenerationInfo);

    }
    internal class FileNameGenerator : IFileNameGenerator { 
    

 
        public FileName GenerateFileName(FileNameGenerationInfo fileNameGenerationInfo) {
            var timeStamp = DateTime.Now;
            FileNameTemplate fileNameTemplate = fileNameGenerationInfo.FileNameTemplate;
            FileName fileName = fileNameGenerationInfo.DateParamFormat == null ? fileNameTemplate.WithoutTimeStamp(): fileNameTemplate.FormatWithTimeStamp(timeStamp, fileNameGenerationInfo.DateParamFormat);
            return fileName;
        } 

    }
}
