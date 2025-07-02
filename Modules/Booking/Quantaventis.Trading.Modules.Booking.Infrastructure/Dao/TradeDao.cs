using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface ITradeDao
    {
        Task UpdateAsync(Trade trade);
        Task DeleteAsync(int tradeId);
        Task UpsertAsync(Trade trade);
        Task<Trade> UpsertByEmsxOrderIdAsync(Trade trade);
        Task<Trade> CreateAsync(Trade trade);
        Task<Trade?> GetByEmsxOrderId(int emsxOrderId);
        Task<Trade?> GetByTradeId(int tradeId);
        Task<Trade?> GetByTradeAllocationId(int tradeAllocationId);
        Task<IEnumerable<Trade>> GetByTradeDateAsync(DateOnly tradeDate);
        Task<IEnumerable<Trade>> GetByInstrumentIdAsync(int instrumentId);
        Task<IEnumerable<Trade>> GetByBookingDateAsync(DateOnly bookingDate);
    }

    internal class TradeDao : ITradeDao
    {
        private BookingDbContext DbContext { get; }

        public TradeDao(BookingDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<Trade> CreateAsync(Trade trade)
        {
            await DbContext.AddAsync(trade);
            await DbContext.SaveChangesAsync();
            return trade;
        }

        public async Task UpdateAsync(Trade trade)
        {
            DbContext.Update(trade);
            await DbContext.SaveChangesAsync();

        }

        public async Task<Trade?> GetByEmsxOrderId(int emsxOrderId)
        {
            return await DbContext
                  .Trades
                  .AsNoTracking()
                   .Include(x => x.TradeAllocations)
                  .Where(x => x.EmsxOrderId == emsxOrderId)
                  .FirstOrDefaultAsync();
        }

        public async Task<Trade?> GetByTradeId(int tradeId)
        {
            return await DbContext
                   .Trades
                   .AsNoTracking()
                    .Include(x => x.TradeAllocations)
                   .Where(x => x.TradeId == tradeId)
                   .FirstOrDefaultAsync();
        }

        public async Task<Trade> UpsertByEmsxOrderIdAsync(Trade entity)
        {
            if (entity.EmsxOrderId != null)
            {
                await DbContext
                 .Upsert(entity)
                 .On(x => x.EmsxOrderId.Value)
                 .RunAsync();
                return entity;
            }
            else
            {
                throw new InvalidOperationException($"Error Upserting ExecutedTrade by EmsxOrderId. EmsxOrderId can't be null");
            }
        }

        public async Task<IEnumerable<Trade>> GetByTradeDateAsync(DateOnly tradeDate)
        {
            var tradeDateTime = tradeDate.ToDateTime(TimeOnly.MinValue);
            return await DbContext
                .Trades
                .AsNoTracking()
                 .Include(x => x.TradeAllocations)
                .Where(x => x.TradeDate == tradeDateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Trade>> GetByInstrumentIdAsync(int instrumentId)
        {
            return await DbContext
               .Trades
               .AsNoTracking()
               .Include(x => x.TradeAllocations)
               .Where(x => x.InstrumentId == instrumentId)
               .ToListAsync();
        }

        public async Task<IEnumerable<Trade>> GetByBookingDateAsync(DateOnly bookingDate)
        {
            var bookingDateTime = bookingDate.ToDateTime(TimeOnly.MinValue);
            return await DbContext
                .Trades
                .AsNoTracking()
                .Include(x => x.TradeAllocations)
                .Where(x => x.BookedOnUtc.Date == bookingDateTime)
                .ToListAsync();
        }

        public async Task<Trade?> GetByTradeAllocationId(int tradeAllocationId)
        {
            return await DbContext
              .Trades
              .AsNoTracking()
              .Include(x => x.TradeAllocations)
              .Where(x => x.TradeAllocations.Select(x => x.TradeAllocationId).Contains(tradeAllocationId))
              .FirstOrDefaultAsync();
        }

        public async Task UpsertAsync(Trade entity)
        {
            await DbContext
             .Upsert(entity)
             .On(x => x.TradeId)
             .RunAsync();
        }

        public async Task DeleteAsync(int tradeId)
        {
            var entity = DbContext.Trades.Where(x => x.TradeId == tradeId);
            if (entity != null)
            {
                DbContext.Remove(entity);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
