using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IRawTradeDao
    {
        Task UpdateAsync(RawTrade trade);
        Task<RawTrade> UpsertByEmsxOrderIdAsync(RawTrade trade);
        Task<RawTrade> CreateAsync(RawTrade trade);
        Task<RawTrade?> GetByEmsxOrderIdAsync(int emsxOrderId);
        Task<RawTrade?> GetByOrderRefIdAsync(int orderRefId);
        Task<IEnumerable<RawTrade>> GetNonBookedAsync();
        Task<RawTrade?> GetByTradeId(int tradeId);
    }

    internal class RawTradeDao : IRawTradeDao
    {
        private BookingDbContext DbContext { get; }
        public RawTradeDao(BookingDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public async Task<RawTrade> CreateAsync(RawTrade trade)
        {
            await DbContext.AddAsync(trade);
            await DbContext.SaveChangesAsync();
            return trade;
        }

        public async Task UpdateAsync(RawTrade trade)
        {
            DbContext.Update(trade);
            await DbContext.SaveChangesAsync();
        }

        public async Task<RawTrade?> GetByEmsxOrderIdAsync(int emsxOrderId)
        {
            return await DbContext
                  .RawTrades
                  .AsNoTracking()
                  .Where(x => x.EmsxOrderId == emsxOrderId)
                  .FirstOrDefaultAsync();
        }

        public async Task<RawTrade?> GetByTradeId(int tradeId)
        {
            return await DbContext
                   .RawTrades
                   .AsNoTracking()
                   .Where(x => x.TradeId == tradeId)
                   .FirstOrDefaultAsync();
        }

        public async Task<RawTrade> UpsertByEmsxOrderIdAsync(RawTrade entity)
        {
            if (entity.EmsxOrderId != null)
            {
                await DbContext
                 .Upsert(entity)
                 .On(x => x.EmsxOrderId)
                 .RunAsync();
                return entity;
            }
            else
            {
                throw new InvalidOperationException($"Error Upserting RawTrade by EmsxOrderId. EmsxOrderId can't be null");
            }
        }

        public async Task<IEnumerable<RawTrade>> GetNonBookedAsync()
        {
            return await DbContext.RawTrades
            .AsNoTracking()
            .GroupJoin(
                DbContext.Trades.AsNoTracking(),
                rawtrd => rawtrd.TradeId,
                booked => booked.TradeId,
                (rawtrd, booked) => new { rawtrd, booked }
            )
            .SelectMany(
                x => x.booked.DefaultIfEmpty(),
                (x, booked) => new { x.rawtrd, booked }
            )
            .Where(x => x.booked == null)
            .Select(x => x.rawtrd)
            .ToListAsync();
        }



        public async Task<RawTrade?> GetByOrderRefIdAsync(int orderRefId)
        {
            return await DbContext
                  .RawTrades
                  .AsNoTracking()
                  .Where(x => x.OrderReferenceId == orderRefId)
                  .FirstOrDefaultAsync();
        }
    }
}
