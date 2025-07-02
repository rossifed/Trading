using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Azure.Storage;
using Azure.Storage.Blobs;
using Quantaventis.Trading.Shared.Infrastructure.IO;
using Azure.Storage.Blobs.Models;
using System.IO.Compression;

namespace Quantaventis.Trading.Shared.Infrastructure.Azure.Storage
{

    public class AzureBlobFileDownloader : IAzureBlobFileDownloader
    {
        private string ConnectionString { get; }
        private string ContainerName { get; }


        public AzureBlobFileDownloader(
            string connectionString,
            string containerName
            )
        {

            ConnectionString = connectionString;
            ContainerName = containerName;

        }


        public async Task<string> DownloadAndDecompressBlobFileAsync(string blobFileName, string downloadFolder)
        {
            var compressedFile = await DownloadBlobFileAsync(blobFileName, downloadFolder);
            return compressedFile;
           
        }
        private bool IsGzipped(Stream stream)
        {
            if (stream.Length < 2)
                return false;



            var br = new BinaryReader(stream);
            var magic = br.ReadUInt16();
            stream.Position = 0; // Reset the position
            return magic == 0x8B1F;
        }
        public async Task<string> DownloadBlobFileAsync(string blobFileName, string downloadFolder)
        {
            var downloadFilePath = Path.Combine(downloadFolder, blobFileName);
            BlobServiceClient blobServiceClient = new BlobServiceClient(ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobFileName);
           
                BlobDownloadInfo download = await blobClient.DownloadAsync();
            using MemoryStream memStream = new MemoryStream();
            blobClient.DownloadTo(memStream);
            memStream.Position = 0;  // Reset the stream position
            MemoryStream currentStream = memStream;

            while (IsGzipped(currentStream))
            {
                using GZipStream decompressionStream = new GZipStream(currentStream, CompressionMode.Decompress);
                var decompressedMemoryStream = new MemoryStream();
                decompressionStream.CopyTo(decompressedMemoryStream);
                decompressedMemoryStream.Position = 0;

                // If the previous stream is not the original memStream, dispose of it
                if (currentStream != memStream)
                {
                    currentStream.Dispose();
                }

                currentStream = decompressedMemoryStream;
            }
            using (FileStream fs = File.OpenWrite(downloadFilePath))
                {
                    await currentStream.CopyToAsync(fs);
                    fs.Close();
                }
            

          
          
            return downloadFilePath;
        }

     
    }
}
