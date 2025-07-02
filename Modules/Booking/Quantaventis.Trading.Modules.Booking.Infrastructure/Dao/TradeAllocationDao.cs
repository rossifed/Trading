using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface ITradeAllocationDao
    {
        Task<IEnumerable<TradeAllocation>> GetByTradeId(int tradeId);
        Task UpsertRangeAsync(IEnumerable<TradeAllocation> entities);
    }

    internal class TradeAllocationDao : ITradeAllocationDao
    {
        private BookingDbContext DbContext { get; }

        public TradeAllocationDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task UpsertRangeAsync(IEnumerable<TradeAllocation> entities)
        {
            await DbContext
                .UpsertRange(entities)
                .On(x =>new { x.TradeAllocationId})
                .RunAsync();
        }


        public async Task<IEnumerable<TradeAllocation>> GetByTradeId(int tradeId)
        {
           return await DbContext
                .TradeAllocations
                .AsNoTracking()
                .Where(x => x.TradeId == tradeId)
                .ToListAsync();
        }

    }
}
