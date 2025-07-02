
namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class FileGenerationProfile
    {
        internal int FileGenerationProfileId { get;  }

        internal FileContentGenerationInfo FileContentGenerationInfo { get; }
        internal FileNameGenerationInfo FileNameGenerationInfo { get; }



        internal Folder OutputFolder { get; set; } = null!;

        public FileGenerationProfile(int fileGenerationProfileId, 
            FileContentGenerationInfo fileContentGenerationInfo, 
            FileNameGenerationInfo fileNameGenerationInfo,
            Folder outputFolder)
        {
            FileGenerationProfileId = fileGenerationProfileId;
            FileContentGenerationInfo = fileContentGenerationInfo;
            FileNameGenerationInfo = fileNameGenerationInfo;
            OutputFolder = outputFolder;
        }

        public override bool Equals(object? obj)
        {
            return obj is FileGenerationProfile profile &&
                   FileGenerationProfileId == profile.FileGenerationProfileId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FileGenerationProfileId);
        }

        public override string? ToString()
        {
            return $"FileGenerationProfile:{FileGenerationProfileId}";
        }
    }
}
