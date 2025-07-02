using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao
{
    internal interface ITargetAllocationValuationDao
    {

        Task<int> CreateAsync(TargetAllocationValuation entity);

  

    }
    internal class TargetAllocationValuationDao : ITargetAllocationValuationDao
    {
        private ValuationDbContext DbContext { get; }

        public TargetAllocationValuationDao(ValuationDbContext dbContext)
        {

            this.DbContext = dbContext;
        }



 

        public async Task<int> CreateAsync(TargetAllocationValuation entity)
        {
            await DbContext.AddAsync(entity);

            await DbContext.SaveChangesAsync();
            return entity.TargetAllocationValuationId;

        }
    }
}
