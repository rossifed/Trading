using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;
using EFCore.BulkExtensions;
namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Dao
{
    internal interface IStgTargetWeightDao
    {

        Task UpdateDataBatch(IEnumerable<StgTargetWeight> data);

    }

    internal class StgTargetWeightDao : IStgTargetWeightDao
    {
        private WeightsDbContext DbContext { get; }

        public StgTargetWeightDao(WeightsDbContext dbContext) {

            this.DbContext = dbContext;
        }


        private async Task TruncateTableAsync()
        {
            var entityType = DbContext.StgTargetWeights.EntityType;
            var query = $"TRUNCATE TABLE {DbContext.Database.GetDbConnection().Database}.{entityType.GetSchemaQualifiedTableName()}";
            await DbContext.Database.ExecuteSqlRawAsync(query);
        }

        public async Task UpdateDataBatch(IEnumerable<StgTargetWeight> data)
        {
            await TruncateTableAsync();
            await DbContext.BulkInsertAsync(data);
        }
    }

}
