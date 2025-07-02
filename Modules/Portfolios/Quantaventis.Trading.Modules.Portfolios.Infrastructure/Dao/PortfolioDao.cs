using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao
{
    internal interface IPortfolioDao
    {
        Task<Portfolio?> GetByIdAsync(byte portfolioId);
        Task<IEnumerable<Portfolio>> GetAllAsync();
        Task<Portfolio> CreateAsync(Portfolio portfolio);
        Task<Portfolio> UpdateAsync(Portfolio portfolio);
    }
    internal class PortfolioDao : IPortfolioDao
    {
        private PortfoliosDbContext DbContext { get; }

        public PortfolioDao(PortfoliosDbContext dbContext)
        {

            this.DbContext = dbContext;
        }


        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            return await DbContext.Portfolios
                       .AsNoTracking()
                       .ToListAsync();
        }

        public async Task<Portfolio> CreateAsync(Portfolio entity)
        {

            await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<Portfolio> UpdateAsync(Portfolio entity)
        {
            DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<Portfolio?> GetByIdAsync(byte portfolioId)
        {
            return await DbContext.Portfolios
                .Where(x => x.PortfolioId == portfolioId)
                   .AsNoTracking()
                   .FirstAsync();
        }
    }
}
