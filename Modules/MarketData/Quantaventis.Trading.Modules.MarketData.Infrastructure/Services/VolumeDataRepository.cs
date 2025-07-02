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
    internal interface IVolumeDataRepository {

        Task UpdateMarketDataAsync();
    }
    internal class VolumeDataRepository : IVolumeDataRepository
    {
        private MarketDataDbContext DbContext { get; }

        public VolumeDataRepository(MarketDataDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task UpdateVolumeData()
        {
            var sql = "EXEC [mktdata].[spMergeVolumeData]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }
        public async Task PropagateMarketData()
        {
            var sql = "EXEC [mktdata].[spPropagateUpdatVolumeData]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }

        public async Task UpdateMarketDataAsync()
        {
            await UpdateVolumeData();
            await PropagateMarketData();
        }
    }
}
