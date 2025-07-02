namespace Quantaventis.Trading.Modules.Transmission.Domain.Exceptions
{
    internal class FileEncryptionException : Exception
    {
        internal string FilePath {get;}
        public FileEncryptionException(string filePath, Exception e): base($"Error encrypting file {filePath}.",e) { 
        this.FilePath = filePath;
        }
    }
}
