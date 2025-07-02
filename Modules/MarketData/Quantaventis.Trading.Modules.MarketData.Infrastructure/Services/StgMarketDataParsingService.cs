using CsvHelper;
using CsvHelper.Configuration;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;
using System.Globalization;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Services
{
    internal class StgMarketDataParsingService : IFileParsingService<StgMarketDatum>
    {


        public StgMarketDataParsingService()
        {
        
        }


            public async Task<IEnumerable<StgMarketDatum>> ParseFileAsync(string csvFilePath)
        {
            var csvRecords = new List<StgMarketDatum>();

            // Create a CSV configuration
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

            // Initialize a CsvReader with your CSV file and configuration
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                csv.Context.RegisterClassMap<StgMarketDataMap>();
                csv.Context.TypeConverterOptionsCache.GetOptions<string>().NullValues.Add("");
                // Read records asynchronously
                await foreach (var record in csv.GetRecordsAsync<StgMarketDatum>())
                {
                    // Add each record to the list asynchronously
                    csvRecords.Add(record);
                }
            }

            return csvRecords;
        }
    }

    internal sealed class StgMarketDataMap : ClassMap<StgMarketDatum> {
        public StgMarketDataMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.RC).Ignore();         
            Map(m => m.DL_SNAPSHOT_START_TIME).Ignore();

        }

    }
}
