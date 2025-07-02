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
    internal interface IMarketDataRepository {

        Task UpdateMarketDataAsync();
    }
    internal class MarketDataRepository : IMarketDataRepository
    {
        private MarketDataDbContext DbContext { get; }

        public MarketDataRepository(MarketDataDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task UpdateMarketData()
        {
            var sql = "EXEC [mktdata].[spMergeMarketData]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }
        public async Task PropagateMarketData()
        {
            var sql = "EXEC [mktdata].[spPropagateUpdateMarketData]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }

        public async Task UpdateMarketDataAsync()
        {
            await UpdateMarketData();
            await PropagateMarketData();
        }
    }
}
