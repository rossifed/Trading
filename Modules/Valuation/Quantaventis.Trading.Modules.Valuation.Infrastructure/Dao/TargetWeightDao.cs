using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao
{
    internal interface ITargetWeightDao
    {
        void DeleteByPortfolioId(byte portfolioId);
        Task CreateAsync(IEnumerable<TargetWeight> entities);
        Task<IEnumerable<TargetWeight>> GetByPortfolioIdAsync(byte portfolioId);
    }
    internal class TargetWeightDao : ITargetWeightDao
    {
        private ValuationDbContext DbContext { get; }

        public TargetWeightDao(ValuationDbContext dbContext)
        {

            this.DbContext = dbContext;
        }



        public async Task<TargetAllocation> GetByPortfolioIdAsync(byte portfolioId)
        {
            return await DbContext.TargetAllocations
                            .AsNoTracking()
                            .Where(x => x.PortfolioId == portfolioId)
                            .Include(x => x.TargetWeights)
                            .ThenInclude(x => x.Instrument)
                            .FirstAsync();
        }

        public async Task CreateAsync(TargetAllocation entity)
        {
            await DbContext.AddAsync(entity);

            await DbContext.SaveChangesAsync();

        }

        public void DeleteByPortfolioId(byte portfolioId)
        {
           //var entity = DbContext.in.Where(x => x.PortfolioId == portfolioId);
           // if(entity.Any())
           // DbContext.Remove(entity);

        }

        public Task CreateAsync(IEnumerable<TargetWeight> entities)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<TargetWeight>> ITargetWeightDao.GetByPortfolioIdAsync(byte portfolioId)
        {
            throw new NotImplementedException();
        }
    }
}
