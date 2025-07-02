namespace Quantaventis.Trading.Shared.Abstractions.Azure.Storage
{
    public interface IAzureBlobFileReader
    {
        Task<T> ReadCompressedBlobFileAsync<T>(string blobFileName, Func<string, T> parse);
        Task<T> ReadBlobFileAsync<T>(string blobFileName, Func<string, T> parse);
        Task<string> ReadCompressedBlobFileAsync(string blobFileName);
        Task<string> ReadBlobFileAsync(string blobFileName);
    }
}
