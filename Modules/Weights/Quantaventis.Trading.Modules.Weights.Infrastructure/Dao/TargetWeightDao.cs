using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Dao
{
    internal interface ITargetWeightDao
    {
 

        Task Create(IEnumerable<TargetWeight> entities);


    }

    internal class TargetWeightDao : ITargetWeightDao
    {
        private WeightsDbContext DbContext { get; }

        public TargetWeightDao(WeightsDbContext dbContext) {

            this.DbContext = dbContext;
        }


        public async Task Create(IEnumerable<TargetWeight> entities)
        {

            await DbContext.AddRangeAsync(entities);
           await DbContext.SaveChangesAsync();
            
        }
    }

}
