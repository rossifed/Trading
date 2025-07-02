using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao
{
    internal interface IPortfolioValuationDao
    {

        Task<int> CreateAsync(PortfolioValuation entity);

    }
    internal class PortfolioValuationDao : IPortfolioValuationDao
    {
        private ValuationDbContext DbContext { get; }

        public PortfolioValuationDao(ValuationDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
     


        public async Task<PortfolioValuation> GetLastByPortfolioIdAsync(int portfolioId)
        {
            return await DbContext.PortfolioValuations
                            .AsNoTracking()
                            .Where(x => x.PortfolioId == portfolioId)
                            .OrderByDescending(x => x.ValuationDate)
                            .FirstAsync();
        }

        public async Task<int> CreateAsync(PortfolioValuation entity)
        {
            await DbContext.AddAsync(entity);

            await DbContext.SaveChangesAsync();
            return entity.PortfolioValuationId;
        }
    }
}
