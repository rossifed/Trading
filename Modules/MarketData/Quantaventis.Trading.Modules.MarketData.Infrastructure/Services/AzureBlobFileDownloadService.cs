using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Options;
using Quantaventis.Trading.Shared.Infrastructure.Azure.Storage;
using Quantaventis.Trading.Shared.Infrastructure.IO;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Services
{
    internal interface IAzureBlobFileDownloadService
    {

        Task<string> DownloadBlobAsync(string blobName);


    }
    internal class AzureBlobFileDownloadService : IAzureBlobFileDownloadService
    {

        private string ConnectionString { get; }
        private string ContainerName { get; }

        private string DownloadFolder { get; }
        private bool DecompressFile { get; }

        private ILogger<AzureBlobFileDownloadService> Logger { get; }

        public AzureBlobFileDownloadService(
            AzureBlobStorageOptions azureBlobStorageOptions,
            ILogger<AzureBlobFileDownloadService> logger)
        {
            ConnectionString = azureBlobStorageOptions.ConnectionString;
            ContainerName = azureBlobStorageOptions.ContainerName;
            DownloadFolder = azureBlobStorageOptions.DownloadFolder;
            DecompressFile = azureBlobStorageOptions.DecompressFile;
            Logger = logger;
        }


        public async Task<string> DownloadBlobAsync(string blobFileName)
        {
            var azureBlobFileDownloader = new AzureBlobFileDownloader(ConnectionString, ContainerName);
            if (DecompressFile)
            {
                var outputFile = await azureBlobFileDownloader.DownloadAndDecompressBlobFileAsync(blobFileName, DownloadFolder);
                Logger.LogInformation($"Blob downloaded to {outputFile}");
                return outputFile;
            }
            else
            {
                var outputFile = await azureBlobFileDownloader.DownloadBlobFileAsync(blobFileName, DownloadFolder);
                Logger.LogInformation($"Blob downloaded to {DownloadFolder}");
                return outputFile;
            }

        }
    }
}
