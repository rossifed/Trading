using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Dao
{
    internal interface IPortfolioDao
    {
        Task<Portfolio?> GetByIdAsync(byte portfolioId);
        Task UpdateAsync(Portfolio entity);
        Task CreateAsync(Portfolio entity);
        Task ReplaceAsync(IEnumerable<Portfolio> entities);
    }
    internal class PortfolioDao : IPortfolioDao
    {
        private RiskDbContext DbContext { get; }

        public PortfolioDao(RiskDbContext dbContext)
        {

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

        public async Task<Portfolio?> GetByIdAsync(byte portfolioId)
        {
           return await DbContext.Portfolios
                .Where(x => x.PortfolioId == portfolioId)
                .FirstOrDefaultAsync();
        }

        public async Task ReplaceAsync(IEnumerable<Portfolio> entities)
        {
            DbContext.Portfolios.RemoveRange(DbContext.Portfolios);
            await DbContext.AddRangeAsync(entities);

            await DbContext.SaveChangesAsync();
        }
    }
}
