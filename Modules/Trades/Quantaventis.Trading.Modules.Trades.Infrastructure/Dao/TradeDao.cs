using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Dao
{
    internal interface ITradeDao
    {
        Task<IEnumerable<Trade>> GetTopTradesAsync(int count);
        Task<IEnumerable<Trade>> GetAllAsync();
        Task<IEnumerable<Trade>> GetByRebalancingIdAsync(int rebalancingId);

        Task<IEnumerable<Trade>> GetByTradeDateAsync(DateOnly tradeDate);

        Task<IEnumerable<Trade>> GetByTradeIdsAsync(IEnumerable<int> tradeIds);
        Task<IEnumerable<Trade>> GetByInstrumentIdAsync(int instrumentId);
        Task UpsertAsync(IEnumerable<Trade> entities);

        Task<IEnumerable<Trade>> CreateAsync(IEnumerable<Trade> entities);
        Task<Trade> SaveAsync(Trade entity);
    }
    internal class TradeDao : ITradeDao
    {
        private TradesDbContext DbContext { get; }

        public TradeDao(TradesDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<Trade>> GetAllAsync()
        {
            return await DbContext.Trades
                              .AsNoTracking()
                              .Include(x => x.TradeAllocations)
                              .Include(x => x.TradeFills)
                              .Include(x => x.Instrument)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Trade>> GetByRebalancingIdAsync(int rebalancingId)
        {
            return await DbContext.Trades
                              .AsNoTracking()
                              .Where(x => x.RebalancingId == rebalancingId)
                              .Include(x => x.TradeAllocations)
                              .Include(x => x.TradeFills)
                              .Include(x => x.Instrument)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Trade>> GetByTradeDateAsync(DateOnly tradeDate)
        {
            var tradeDateTime = tradeDate.ToDateTime(TimeOnly.MinValue);
            return await DbContext.Trades
                              .AsNoTracking()
                              .Where(x => x.TradeDate.CompareTo(tradeDateTime) == 0)
                              .Include(x => x.TradeAllocations)
                              .Include(x => x.TradeFills)
                              .Include(x => x.Instrument)
                              .ToListAsync();
        }


        public async Task<IEnumerable<Trade>> GetByInstrumentIdAsync(int instrumentId)
        {
            return await DbContext.Trades
                              .AsNoTracking()
                              .Where(x => x.InstrumentId == instrumentId)
                              .Include(x => x.TradeAllocations)
                              .Include(x => x.TradeFills)
                              .Include(x => x.Instrument)
                              .ToListAsync();
        }
        public async Task UpsertAsync(IEnumerable<Trade> entities)
        {
            await DbContext
                    .UpsertRange(entities)
                    .On(x => x.TradeId)
                    .WhenMatched(x => new Trade()
                    {
                        OrderId = x.OrderId,
                        RebalancingId = x.RebalancingId,
                        EmsxSequence = x.EmsxSequence,
                   
                        EmsxOrderCreatedOn = x.EmsxOrderCreatedOn,
                        InstrumentId = x.InstrumentId,
                        ExchangeCode = x.ExchangeCode,
                        Sedol = x.Sedol,
                        BuySellIndicator = x.BuySellIndicator,
                        OrderQuantity = x.OrderQuantity,
                        FilledQuantity = x.FilledQuantity,
                        AvgPrice = x.AvgPrice,
                        DayAveragePrice = x.DayAveragePrice,
                        TradeCurrency = x.TradeCurrency,
                        TradeDate = x.TradeDate,
                        Principal = x.Principal,
                        NetAmount = x.NetAmount,
                        SettlementDate = x.SettlementDate,
                        SettlementCurrency = x.SettlementCurrency,
                        BrokerCommission = x.BrokerCommission,
                        CommissionRate = x.CommissionRate,
                        MiscFees = x.MiscFees,
                        Notes = x.Notes,
                        BrokerCode = x.BrokerCode,
                        TradeDesk = x.TradeDesk,
                        IsCfd = x.IsCfd,
                      //  TradeMode = x.TradeMode,
                        ExecutionChannel = x.ExecutionChannel,
                    })
                    .RunAsync();

        }
        public async Task<IEnumerable<Trade>> CreateAsync(IEnumerable<Trade> entities)
        {
            await DbContext.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
            return entities;
        }
        public async Task<Trade> SaveAsync(Trade entity)
        {
            if (entity.TradeId <= 0)
                await DbContext.AddAsync(entity);
            else
                DbContext.UpdateRange(entity);

            await DbContext.SaveChangesAsync();
            return entity;

        }

        public async Task<IEnumerable<Trade>> GetByTradeIdsAsync(IEnumerable<int> tradeIds)
        {
            return await DbContext.Trades
                              .AsNoTracking()
                              .Where(x => tradeIds.Contains(x.TradeId))
                              .Include(x => x.TradeAllocations)
                              .Include(x => x.TradeFills)
                              .Include(x => x.Instrument)
                              .ToListAsync();
        }

        public async Task<IEnumerable<Trade>> GetTopTradesAsync(int count)
        {
            return await DbContext.Trades
                       .AsNoTracking()  
                       .Include(x => x.TradeAllocations)
                       .Include(x => x.TradeFills)
                       .Include(x => x.Instrument)
                       .OrderByDescending(t => t.TradeId) 
                       .Take(count)
                       .ToListAsync();
        }
    }
}

