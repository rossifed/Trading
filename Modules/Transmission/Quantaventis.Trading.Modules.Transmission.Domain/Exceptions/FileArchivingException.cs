namespace Quantaventis.Trading.Modules.Transmission.Domain.Exceptions
{
    internal class FileArchivingException : Exception
    {
        internal string FilePath {get;}

        internal string ArchiveDirectory { get; }
        public FileArchivingException(string filePath, string archivedir, Exception e): base($"Error archiving file {filePath} into {archivedir} directory",e) { 
        this.FilePath = filePath;
        this.ArchiveDirectory = archivedir;
        }
    }
}
