using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.EntityFrameworkCore.Storage;
using Quantaventis.Trading.Modules.Instruments.Domain.Model;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using System;
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Services
{
    internal class StgRefDataParsingService : IFileParsingService<StgRefDatum>
    {


        public StgRefDataParsingService()
        {
        
        }


            public async Task<IEnumerable<StgRefDatum>> ParseFileAsync(string csvFilePath)
        {
            var csvRecords = new List<StgRefDatum>();

            // Create a CSV configuration
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

            // Initialize a CsvReader with your CSV file and configuration
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                csv.Context.RegisterClassMap<StgRefDataMap>();
                // Read records asynchronously
                await foreach (var record in csv.GetRecordsAsync<StgRefDatum>())
                {
                    // Add each record to the list asynchronously
                    csvRecords.Add(record);
                }
            }

            return csvRecords;
        }
    }

    internal sealed class StgRefDataMap : ClassMap<StgRefDatum> {
        public StgRefDataMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.EXCHANGE_TRADING_SESSION_HOURS_FUT_TRADING_HRS).Ignore();
            Map(m => m.EXCHANGE_TRADING_SESSION_HOURS_BC_SESSION).Ignore();

        }

    }
}
