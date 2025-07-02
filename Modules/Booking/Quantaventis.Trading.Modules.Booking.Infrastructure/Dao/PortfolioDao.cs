using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IPortfolioDao
    {
        Task<Portfolio?> GetByIdAsync(int portfolioId);
    }

    internal class PortfolioDao : IPortfolioDao
    {
        private BookingDbContext DbContext { get; }

        public PortfolioDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Portfolio?> GetByIdAsync(int portfolioId)
        {
            return await DbContext
              .Portfolios
              .AsNoTracking()
              .Where(x => x.PortfolioId == portfolioId)
              .FirstOrDefaultAsync();
        }
    }
}
