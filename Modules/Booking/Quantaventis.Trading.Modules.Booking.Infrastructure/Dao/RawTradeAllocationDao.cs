using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IRawTradeAllocationDao
    {
        Task<IEnumerable<RawTradeAllocation>> CreateRangeAsync(IEnumerable<RawTradeAllocation> entities);
        Task CreateAsync(RawTradeAllocation entity);
        Task<IEnumerable<RawTradeAllocation>> GetByTradeId(int tradeId);
        Task UpsertRangeAsync(IEnumerable<RawTradeAllocation> entities);
    }

    internal class RawTradeAllocationDao : IRawTradeAllocationDao
    {
        private BookingDbContext DbContext { get; }

        public RawTradeAllocationDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task UpsertRangeAsync(IEnumerable<RawTradeAllocation> entities)
        {
            await DbContext
                .UpsertRange(entities)
                .On(x =>new { x.TradeId, x.PortfolioId})
                .RunAsync();
        }


        public async Task<IEnumerable<RawTradeAllocation>> GetByTradeId(int tradeId)
        {
           return await DbContext
                .RawTradeAllocations
                .AsNoTracking()
                .Where(x => x.TradeId == tradeId)
                .ToListAsync();
        }

        public async Task CreateAsync(RawTradeAllocation entity)
        {
          await  DbContext.AddAsync(entity);
          await  DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RawTradeAllocation>> CreateRangeAsync(IEnumerable<RawTradeAllocation> entities)
        {
            await DbContext.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
            return entities;
        }
    }
}
