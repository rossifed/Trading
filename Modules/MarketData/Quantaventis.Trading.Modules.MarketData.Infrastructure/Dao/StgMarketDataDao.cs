using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Dao
{
    internal interface IStgMarketDataDao
    {

        Task UpdateDataBatch(IEnumerable<StgMarketDatum> data);

    }
    internal class StgMarketDataDao : IStgMarketDataDao
    {
        private MarketDataDbContext DbContext { get; }

        public StgMarketDataDao(MarketDataDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        private async Task TruncateTableAsync()
        {
            var entityType = DbContext.StgMarketData.EntityType;
            var query = $"TRUNCATE TABLE {DbContext.Database.GetDbConnection().Database}.{entityType.GetSchemaQualifiedTableName()}";
            await DbContext.Database.ExecuteSqlRawAsync(query);
        }

        public async Task UpdateDataBatch(IEnumerable<StgMarketDatum> data)
        {
            await TruncateTableAsync();
            await DbContext.BulkInsertAsync(data);
        }
    }
}
