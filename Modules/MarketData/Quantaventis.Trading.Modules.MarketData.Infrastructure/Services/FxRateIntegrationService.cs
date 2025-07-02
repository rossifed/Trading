using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Dao;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Services
{
    internal interface IFxRateIntegrationService {

        Task UpdateFxRatesAsync();
    }
    internal class FxRateIntegrationService : IFxRateIntegrationService
    {
        private MarketDataDbContext DbContext { get; }

        public FxRateIntegrationService(MarketDataDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task UpdateFxRates()
        {
            var sql = "EXEC [mktdata].[spMergeMarketDataIntoFxRate]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }
        public async Task PropagateFxRates()
        {
            var sql = "EXEC [mktdata].[spPropagateUpdateFxRates]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }

        public async Task UpdateFxRatesAsync()
        {
            await UpdateFxRates();
            await PropagateFxRates();
        }
    }
}
