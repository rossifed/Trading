using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Repositories
{
    internal interface ITradeBookingRepository
    {
        Task<IEnumerable<Trade>> BookTradesAsync();
    }
    internal class TradeBookingRepository : ITradeBookingRepository
    {
        private TradesDbContext DbContext { get; }
        private ITradeDao TradeDao { get; }

        public TradeBookingRepository(TradesDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<Trade>> BookTradesAsync()
        {
            var entities = await DbContext.Set<Trade>().FromSqlRaw("[trd].[spBookTrades]").ToListAsync();
     
            return entities;
        }
        private class BookedTrade
        {
            public int TradeId { get; set; }
        }

    }
}
