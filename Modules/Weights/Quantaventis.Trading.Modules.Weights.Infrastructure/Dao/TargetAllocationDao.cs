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
    internal interface ITargetAllocationDao
    {
 

        Task<int> CreateAsync(TargetAllocation entity);


    }

    internal class TargetAllocationDao : ITargetAllocationDao
    {
        private WeightsDbContext DbContext { get; }

        public TargetAllocationDao(WeightsDbContext dbContext) {

            this.DbContext = dbContext;
        }


        public async Task<int> CreateAsync(TargetAllocation entity)
        {

            await DbContext.AddAsync(entity);
           await DbContext.SaveChangesAsync();
            return entity.TargetAllocationId;
        }
    }

}
