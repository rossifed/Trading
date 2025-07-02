using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Services
{
    internal interface IAzureBlobFileIntegrationService
    {
        Task IntegrateAzureBlobFileIntoDb(string blobFileName);
    }
    internal class AzureBlobFileIntegrationService : IAzureBlobFileIntegrationService
    {
       private  IAzureBlobFileDownloadService AzureBlobFileDownloadService { get; }
        private IFileToDBIntegrationService FileToDBIntegrationService { get; }

        public AzureBlobFileIntegrationService(
            IAzureBlobFileDownloadService azureBlobFileDownloadService, 
            IFileToDBIntegrationService fileToDBIntegrationService)
        {
            AzureBlobFileDownloadService = azureBlobFileDownloadService;
            FileToDBIntegrationService = fileToDBIntegrationService;
        }

        public async Task IntegrateAzureBlobFileIntoDb(string blobFileName) {
          string filePath =await AzureBlobFileDownloadService.DownloadBlobAsync(blobFileName);
            await FileToDBIntegrationService.IntegrateFileIntoDBAsync(filePath);

          }
    }
}
