using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Services
{
  
    internal class FileImportService<T> : IFileImportService<T>
    {
        IFileParsingService<T> FileParsingService { get; }
        IDBIntegrationService<T> DBIntegrationService { get; }

        public FileImportService(IFileParsingService<T> fileRawMappingService, 
            IDBIntegrationService<T> dBIntegrationService)
        {
            FileParsingService = fileRawMappingService;
            DBIntegrationService = dBIntegrationService;
        }

        public async Task IntegrateFileIntoDBAsync(string filePath) {

            IEnumerable<T> stgMarketData = await FileParsingService.ParseFileAsync(filePath);
            await  DBIntegrationService.IntegrateDataBatchAsync(stgMarketData);
        }
    }
}
