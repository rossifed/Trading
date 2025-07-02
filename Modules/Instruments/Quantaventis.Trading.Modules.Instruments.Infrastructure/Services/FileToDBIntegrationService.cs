using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Services
{
    internal interface IFileToDBIntegrationService {
        Task IntegrateFileIntoDBAsync(string filePath);
    }
    internal class FileToDBIntegrationService : IFileToDBIntegrationService
    {
        IFileParsingService<StgRefDatum> FileParsingService { get; }
        IDBIntegrationService<StgRefDatum> DBIntegrationService { get; }

        public FileToDBIntegrationService(IFileParsingService<StgRefDatum> fileRawMappingService, 
            IDBIntegrationService<StgRefDatum> dBIntegrationService)
        {
            FileParsingService = fileRawMappingService;
            DBIntegrationService = dBIntegrationService;
        }

        public async Task IntegrateFileIntoDBAsync(string filePath) {

            IEnumerable<StgRefDatum> stgRefData = await FileParsingService.ParseFileAsync(filePath);
            await  DBIntegrationService.IntegrateDataBatchAsync(stgRefData);
        }
    }
}
