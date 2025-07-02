using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IOrderDao
    {
        Task<IEnumerable<Order>> GetByInstrumentAndTradeDateAsync(int instrumentId, DateOnly tradeDate);
        Task<Order?> GetByOrderId(int orderId);
        Task UpsertAsync(Order entity);

        Task UpsertRangeAsync(IEnumerable<Order> entities);
    }

    internal class OrderDao : IOrderDao
    {
        private BookingDbContext DbContext { get; }

        public OrderDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task UpsertAsync(Order entity)
        {
            await DbContext
                .Upsert(entity)
                .On(x =>new { x.OrderId })
                .RunAsync();
        }
        public async Task UpsertRangeAsync(IEnumerable<Order> entities)
        {
            await DbContext
                .UpsertRange(entities)
                .On(x => new { x.OrderId })
                .RunAsync();
        }

        public async Task<Order?> GetByOrderId(int orderId)
        {
           return await DbContext
                .Orders
                .AsNoTracking()
                .Include(x => x.OrderAllocations)
                .Where(x => x.OrderId == orderId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetByInstrumentAndTradeDateAsync(int instrumentId, DateOnly tradeDate)
        { var tradeDateTime = tradeDate.ToDateTime(TimeOnly.MinValue);
            return await DbContext
              .Orders
              .AsNoTracking()
              .Include(x => x.OrderAllocations)
              .Where(x => x.InstrumentId == instrumentId && x.TradeDate == tradeDateTime)
              .ToListAsync();
        }
    }
}
