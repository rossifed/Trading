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
    internal interface IPortfolioDao
    {

  
        Task CreateAsync(Portfolio portfolio);
        Task UpdateAsync(Portfolio portfolio);

        Task ReplaceAsync(IEnumerable<Portfolio> portfolios);
    }

    internal class PortfolioDao : IPortfolioDao
    {
        private RebalancingDbContext DbContext { get; }

        public PortfolioDao(RebalancingDbContext dbContext) {

            this.DbContext = dbContext;
        }

        public async Task CreateAsync(Portfolio entity)
        {
           await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Portfolio entity)
        {
             DbContext.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task ReplaceAsync(IEnumerable<Portfolio> entities)
        {
            DbContext.Portfolios.RemoveRange(DbContext.Portfolios);
            await DbContext.AddRangeAsync(entities);

            await DbContext.SaveChangesAsync();
        }
    }

}
