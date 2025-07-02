using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Dao
{
    internal interface IEmsxOrderDao
    {
        Task<IEnumerable<EmsxOrder>> GetAllAsync();

        Task ReplaceAsync(IEnumerable<EmsxOrder> entities);

        Task UpsertAsync(IEnumerable<EmsxOrder> entities);
    }
    internal class EmsxOrderDao : IEmsxOrderDao
    {
        private TradesDbContext DbContext { get; }

        public EmsxOrderDao(TradesDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<EmsxOrder>> GetAllAsync()
        {
            return await DbContext.EmsxOrders
                              .AsNoTracking()
                              .ToListAsync();
        }
  

        public async Task ReplaceAsync(IEnumerable<EmsxOrder> entities)
        {
            DbContext.RemoveRange(DbContext.EmsxOrders);
            await DbContext.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
        }
        public async Task UpsertAsync(IEnumerable<EmsxOrder> entities)
        {
            await DbContext.EmsxOrders
                      .UpsertRange(entities)
                      .On(x => x.EmsxSequence)
                      .WhenMatched(x => new EmsxOrder()
                      {
                          Ticker = x.Ticker,
                          EmsxDate = x.EmsxDate,
                          OrderNumber = x.OrderNumber,
                          OrderRefId = x.OrderRefId,
                          Status = x.Status,
     
                          Isin = x.Isin,
                          Sedol = x.Sedol,
                          Exchange = x.Exchange,
                          Side = x.Side,
                          Amount = x.Amount,
                          Filled = x.Filled,
                          AvgPrice = x.AvgPrice,
                          DayAvgPrice = x.DayAvgPrice,
                          LimitPrice = x.LimitPrice,
                          Principal = x.Principal,
                          BrokerCommm = x.BrokerCommm,
                          CommmRate = x.CommmRate,
                          MiscFees = x.MiscFees,
                          OrderType = x.OrderType,
                          TimeInForce = x.TimeInForce,
                          Strategy = x.Strategy,
                          HandInstruction = x.HandInstruction,
                          Broker = x.Broker,
                          Account = x.Account,
                          CfdFlag = x.CfdFlag,
                          SettleCurrency = x.SettleCurrency,
                          SettleAmount = x.SettleAmount,
                          ClearingAccount = x.ClearingAccount,
                          ClearingFirm = x.ClearingFirm,
                          BasketName = x.BasketName,
                          CustomNote1 = x.CustomNote1,
                          CustomNote2 = x.CustomNote2,
                          CustomNote3 = x.CustomNote3,
                          CustomNote4 = x.CustomNote4,
                          CustomNote5 = x.CustomNote5,
                          Notes = x.Notes,
                          TraderUuid = x.TraderUuid,
                          Trader = x.Trader,
        
                          PercentRemain = x.PercentRemain,
                          YellowKey = x.YellowKey,
                          SettleDate = x.SettleDate,
                          TimeStamp = x.TimeStamp,
                          LastFillDate = x.LastFillDate


                      })
                      .RunAsync();
        }

    }
}

