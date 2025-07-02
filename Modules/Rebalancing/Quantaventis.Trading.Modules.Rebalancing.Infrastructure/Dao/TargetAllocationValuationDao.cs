using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao
{
    internal interface ITargetAllocationValuationDao
    {
 

        Task<TargetAllocationValuation?> GetLastByPortfolioIdAsync(byte portfolioId);
        Task CreateAsync(TargetAllocationValuation entity);

        Task ReplaceAsync(TargetAllocationValuation entity);

    }

    internal class TargetAllocationValuationDao : ITargetAllocationValuationDao
    {
        private RebalancingDbContext DbContext { get; }

        public TargetAllocationValuationDao(RebalancingDbContext dbContext) {

            this.DbContext = dbContext;
        }


       public async Task<TargetAllocationValuation?> GetLastByPortfolioIdAsync(byte portfolioId)
        {
            return await DbContext.TargetAllocationValuations
                 .AsNoTracking()
                 .Where(x => x.PortfolioId == portfolioId)
                 .Include(x => x.TargetWeightValuations)
                 .OrderByDescending(x => x.ValuatedOn)
                 .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(TargetAllocationValuation entity)
        {
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task ReplaceAsync(TargetAllocationValuation entity)
        {
            DbContext.RemoveRange(DbContext.TargetAllocationValuations.Where(x=>x.PortfolioId == entity.PortfolioId));
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }
    }

}
