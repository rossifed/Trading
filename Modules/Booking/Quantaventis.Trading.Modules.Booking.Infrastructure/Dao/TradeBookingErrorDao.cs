using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface ITradeBookingErrorDao
    {
        Task CreateAsync(TradeBookingError error);
        Task DeleteByTradeIdAsync (int  tradeId);
        Task<IEnumerable<TradeBookingError>> GetByTradeIdAsync(int tradeId);
        Task<IEnumerable<TradeBookingError>> GetAllAsync();
    }

    internal class TradeBookingErrorDao : ITradeBookingErrorDao
    {
        private BookingDbContext DbContext { get; }

        public TradeBookingErrorDao(BookingDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task CreateAsync(TradeBookingError error)
        {
            await DbContext.AddAsync(error);
            await DbContext.SaveChangesAsync();
           
        }

        public async Task DeleteByTradeIdAsync(int tradeId)
        {
            IEnumerable <TradeBookingError> entities = await GetByTradeIdAsync(tradeId);

            DbContext.TradeBookingErrors.RemoveRange(entities);
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TradeBookingError>> GetByTradeIdAsync(int tradeId)
        {
            return await DbContext
                  .TradeBookingErrors
                  .AsNoTracking()
                  .Where(x => x.TradeId == tradeId)
                  .ToListAsync();
        }

        public async Task<IEnumerable<TradeBookingError>> GetAllAsync()
        {
            return await DbContext
                 .TradeBookingErrors
                 .AsNoTracking()
                 .ToListAsync();
        }
    }
}
