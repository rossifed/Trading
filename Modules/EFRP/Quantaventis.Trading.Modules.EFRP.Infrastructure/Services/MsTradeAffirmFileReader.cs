using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Dto;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Mappers;
using Quantaventis.Trading.Shared.Abstractions.Events;
namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Services
{
    internal interface IMsTradeAffirmFileReader {

        Task<IEnumerable<TradeAffirmFutureItem>> ReadTradeAffirmFutureItemsAsync(string csvFilePath);
    }
    internal class MsTradeAffirmFileReader : IMsTradeAffirmFileReader
    {

        IEventDispatcher EventDispatcher { get; }
        public async Task<IEnumerable<TradeAffirmFutureItem>> ReadTradeAffirmFutureItemsAsync(string csvFilePath)
        {
            var tradeAffirmItemDtos = await ReadTradeAffirmFileAsync(csvFilePath);
            return tradeAffirmItemDtos.Map();
        }

        private async Task<IEnumerable<MsTradeAffirmItemDto>> ReadTradeAffirmFileAsync(string csvFilePath)
        {
            var csvRecords = new List<MsTradeAffirmItemDto>();

            // Create a CSV configuration
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

            // Initialize a CsvReader with your CSV file and configuration
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, csvConfig))
            {
               // csv.Context.RegisterClassMap<MsTradeAffirmItemDto>();
                // Read records asynchronously
                await foreach (var record in csv.GetRecordsAsync<MsTradeAffirmItemDto>())
                {
                    // Add each record to the list asynchronously
                    csvRecords.Add(record);
                }
            }

            return csvRecords;
        }
    }
}
