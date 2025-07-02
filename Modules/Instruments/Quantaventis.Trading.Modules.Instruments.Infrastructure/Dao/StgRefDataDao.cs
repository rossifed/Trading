using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCore.BulkExtensions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface IStgRefDataDao
    {

        Task UpdateDataBatch(IEnumerable<StgRefDatum> data);

    }
    internal class StgRefDataDao : IStgRefDataDao
    {
        private InstrumentsDbContext DbContext { get; }

        public StgRefDataDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        private async Task TruncateTableAsync()
        {
            var entityType = DbContext.StgRefData.EntityType;
            var query = $"TRUNCATE TABLE {DbContext.Database.GetDbConnection().Database}.{entityType.GetSchemaQualifiedTableName()}";
            await DbContext.Database.ExecuteSqlRawAsync(query);
        }
        private async Task DeleteTableAsync()
        {
            var entityType = DbContext.StgRefData.EntityType;
            var query = $"DELETE FROM {DbContext.Database.GetDbConnection().Database}.{entityType.GetSchemaQualifiedTableName()}";
            await DbContext.Database.ExecuteSqlRawAsync(query);
        }
        public async Task UpdateDataBatch(IEnumerable<StgRefDatum> data)
        {
            await DeleteTableAsync();
            await DbContext.BulkInsertAsync(data);
        }
    }
}
