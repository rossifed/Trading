using CsvHelper;
using CsvHelper.Configuration;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;
using System.Globalization;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Services
{
    internal class StgVolumeDataParsingService : IFileParsingService<StgVolumeDatum>
    {


        public StgVolumeDataParsingService()
        {
        
        }


            public async Task<IEnumerable<StgVolumeDatum>> ParseFileAsync(string csvFilePath)
        {
            var csvRecords = new List<StgVolumeDatum>();

            // Create a CSV configuration
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

            // Initialize a CsvReader with your CSV file and configuration
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                csv.Context.RegisterClassMap<StgVolumeDataMap>();
                csv.Context.TypeConverterOptionsCache.GetOptions<string>().NullValues.Add("");
                // Read records asynchronously
                await foreach (var record in csv.GetRecordsAsync<StgVolumeDatum>())
                {
                    // Add each record to the list asynchronously
                    csvRecords.Add(record);
                }
            }

            return csvRecords;
        }
    }

    internal sealed class StgVolumeDataMap : ClassMap<StgVolumeDatum> {
        public StgVolumeDataMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.RC).Ignore();

        }

    }
}
