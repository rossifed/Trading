using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IOrderAllocationDao
    {
        Task<IEnumerable<OrderAllocation>> GetByOrderId(int orderId);
        Task UpsertRangeAsync(IEnumerable<OrderAllocation> entities);
    }

    internal class OrderAllocationDao : IOrderAllocationDao
    {
        private BookingDbContext DbContext { get; }

        public OrderAllocationDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task UpsertRangeAsync(IEnumerable<OrderAllocation> entities)
        {
            await DbContext
                .UpsertRange(entities)
                .On(x => new { x.OrderId, x.PortfolioId })
                .RunAsync();
        }

        public async Task<IEnumerable<OrderAllocation>> GetByOrderId(int orderId)
        {
            return await DbContext
                 .OrderAllocations
                 .AsNoTracking()
                 .Where(x => x.OrderId == orderId)
                 .ToListAsync();
        }

        public Task<IEnumerable<Order>> GetByInstrumentAndTradeDateAsync(int instrumentId, DateOnly tradeDate)
        {
            throw new NotImplementedException();
        }
    }
}
