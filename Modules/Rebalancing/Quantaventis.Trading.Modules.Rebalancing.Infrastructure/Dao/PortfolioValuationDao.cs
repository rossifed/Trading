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
    internal interface IPortfolioValuationDao
    {
 

        Task<PortfolioValuation?> GetLastByPortfolioIdAsync(byte portfolioId);
        Task ReplaceAsync(PortfolioValuation entity);

    }

    internal class PortfolioValuationDao : IPortfolioValuationDao
    {
        private RebalancingDbContext DbContext { get; }

        public PortfolioValuationDao(RebalancingDbContext dbContext) {

            this.DbContext = dbContext;
        }

   

        public async Task<PortfolioValuation?> GetLastByPortfolioIdAsync(byte portfolioId)
        {

            return await DbContext.PortfolioValuations
                 .AsNoTracking()
                 .Where(x => x.PortfolioId == portfolioId)
                 .Include(x => x.PositionValuations)
                 .OrderByDescending(x => x.ValuationDate)
                 .FirstOrDefaultAsync();
        }

        public async Task ReplaceAsync(PortfolioValuation entity)
        {
            DbContext.RemoveRange(DbContext.PortfolioValuations.Where(x => x.PortfolioId == entity.PortfolioId));
            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }
    }

}
