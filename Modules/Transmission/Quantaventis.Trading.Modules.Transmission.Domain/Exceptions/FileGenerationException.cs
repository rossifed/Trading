namespace Quantaventis.Trading.Modules.Transmission.Domain.Exceptions
{
    internal class FileGenerationException : Exception
    {
        internal string FilePath {get;}
        public FileGenerationException(string filePath, Exception e): base($"Error generating file {filePath}.",e) { 
        this.FilePath = filePath;
        }
    }
}
