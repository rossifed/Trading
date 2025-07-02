using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Dao
{
    internal interface IStgVolumeDataDao
    {

        Task UpdateDataBatch(IEnumerable<StgVolumeDatum> data);

    }
    internal class StgVolumeDataDao : IStgVolumeDataDao
    {
        private MarketDataDbContext DbContext { get; }

        public StgVolumeDataDao(MarketDataDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        private async Task TruncateTableAsync()
        {
            var entityType = DbContext.StgVolumeData.EntityType;
            var query = $"TRUNCATE TABLE {DbContext.Database.GetDbConnection().Database}.{entityType.GetSchemaQualifiedTableName()}";
            await DbContext.Database.ExecuteSqlRawAsync(query);
        }

        public async Task UpdateDataBatch(IEnumerable<StgVolumeDatum> data)
        {
            await TruncateTableAsync();
            await DbContext.BulkInsertAsync(data);
        }
    }
}
