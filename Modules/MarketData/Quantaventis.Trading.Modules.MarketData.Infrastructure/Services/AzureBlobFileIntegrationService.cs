using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Dao;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Services
{
    internal interface IAzureBlobFileIntegrationService<T>
    {
        Task IntegrateAzureBlobFileIntoDb(string blobFileName);
    }
    internal class AzureBlobFileIntegrationService<T> : IAzureBlobFileIntegrationService<T>
    {
       private  IAzureBlobFileDownloadService AzureBlobFileDownloadService { get; }
        private IFileImportService<T> FileIntegrationService { get; }

        public AzureBlobFileIntegrationService(
            IAzureBlobFileDownloadService azureBlobFileDownloadService, 
            IFileImportService<T> fileToDBIntegrationService)
        {
            AzureBlobFileDownloadService = azureBlobFileDownloadService;
            FileIntegrationService = fileToDBIntegrationService;
        }

        public async Task IntegrateAzureBlobFileIntoDb(string blobFileName) {
          string filePath =await AzureBlobFileDownloadService.DownloadBlobAsync(blobFileName);
            await FileIntegrationService.IntegrateFileIntoDBAsync(filePath);

          }
    }
}
