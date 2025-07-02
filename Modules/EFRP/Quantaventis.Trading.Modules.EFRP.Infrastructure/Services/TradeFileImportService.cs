using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Services
{
    internal interface ITradeFileImportService
    {

        Task ImportTradesFileAsync(string tradeFilePath, string tableName, bool truncateTable);
    }
    internal class TradeFileImportService : ITradeFileImportService
    {
        private ICsvReaderService CsvReaderService { get; }

        private IFileIntegrationService FileIntegrationService { get; }

        public TradeFileImportService(ICsvReaderService csvReaderService, IFileIntegrationService fileIntegrationService)
        {
            CsvReaderService = csvReaderService;
            FileIntegrationService = fileIntegrationService;
        }

        public async Task ImportTradesFileAsync(string tradeFilePath, string tableName, bool truncateTable)
        {
            var dataTable = CsvReaderService.ReadToDataTable(tradeFilePath);
            await FileIntegrationService.InsertCsvToTableAsync(tableName, dataTable);
        }
    }
}
