using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao
{
    internal interface ITargetAllocationDao
    {
        void DeleteByPortfolioId(byte portfolioId);
        Task CreateAsync(TargetAllocation entity);

        Task ReplaceAsync(TargetAllocation entity);
        Task<TargetAllocation?> GetLastByPortfolioIdAsync(byte portfolioId);

        Task<IEnumerable<TargetAllocation>> GetAllAsync();
    }
    internal class TargetAllocationDao : ITargetAllocationDao
    {
        private ValuationDbContext DbContext { get; }

        public TargetAllocationDao(ValuationDbContext dbContext)
        {

            this.DbContext = dbContext;
        }



        public async Task<TargetAllocation?> GetLastByPortfolioIdAsync(byte portfolioId)
        {
            return await DbContext.TargetAllocations
                            .AsNoTracking()
                            .Where(x => x.PortfolioId == portfolioId)
                            .Include(x => x.TargetWeights)
                            .ThenInclude(x => x.Instrument)
                            .ThenInclude(x=> x.FutureContract)
                            .OrderByDescending(x => x.TargetAllocationId)//maybe use the genratedon property??
                            .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(TargetAllocation entity)
        {
            await DbContext.AddAsync(entity);

            await DbContext.SaveChangesAsync();

        }

        public void DeleteByPortfolioId(byte portfolioId)
        {
           var entity = DbContext.TargetAllocations.Where(x => x.PortfolioId == portfolioId);
            if(entity.Any())
            DbContext.Remove(entity);

        }

        public async Task ReplaceAsync(TargetAllocation entity)
        {
            DbContext.TargetAllocations.RemoveRange(DbContext.TargetAllocations.Where(x=>x.PortfolioId == entity.PortfolioId));
            await DbContext.AddAsync(entity);

            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TargetAllocation>> GetAllAsync()
        {
            return await DbContext.TargetAllocations
                      .AsNoTracking()
                      .Include(x => x.TargetWeights)
                      .ThenInclude(x => x.Instrument)
                      .ThenInclude(x => x.FutureContract)
                      .ToListAsync();
        }
    }
}
