using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Dao
{
    internal interface IPortfolioDao
    {
        Task UpdateAsync(Portfolio entity);
        Task CreateAsync(Portfolio entity);
        Task<IEnumerable<Portfolio>> GetAllAsync();
        Task ReplaceAsync(IEnumerable<Portfolio> entities);
    }
    internal class PortfolioDao : IPortfolioDao
    {
        private OrdersDbContext DbContext { get; }

        public PortfolioDao(OrdersDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            return await DbContext.Portfolios
                              .AsNoTracking()
                              .ToListAsync();
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
