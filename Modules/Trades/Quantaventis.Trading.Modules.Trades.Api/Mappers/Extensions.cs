using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Trades.Api.Dto;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Entities =Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Trades.Api.Mappers
{
    internal static class Extensions
    {
        public static IEnumerable<Entities.EmsxOrder> Map(this IEnumerable<EmsxOrderDto> dtos) {
           return dtos.Select(x => x.Map()).ToList();
        
        }
        public static Entities.EmsxOrder Map(this EmsxOrderDto dto)
        {
            return new Entities.EmsxOrder()
            {
                EmsxSequence =dto.Sequence.GetValueOrDefault(),
                OrderNumber = dto.OrderNumber.GetValueOrDefault(),
                OrderRefId = dto.OrderRefId,
                Ticker = dto.Ticker,
                Isin = dto.Isin,
                Sedol = dto.Sedol,
                Exchange = dto.Exchange,
                BasketName = dto.BasketName,
                Side = dto.Side,
                Amount = dto.Amount,
                Status = dto.Status,
                Filled  = dto.Filled.GetValueOrDefault(),
                AvgPrice = (decimal)dto.AvgPrice.GetValueOrDefault(),
                DayAvgPrice = (decimal)dto.DayAvgPrice.GetValueOrDefault(),
                LimitPrice = (decimal)dto.LimitPrice.GetValueOrDefault(),
                OrderType   = dto.OrderType,
                TimeInForce = dto.TimeInForce,  
                Strategy = dto.StrategyType,
                HandInstruction = dto.HandInstruction,
                Broker = dto.Broker,
                Account = dto.Account,
                CfdFlag = dto.CfdFlag,
                SettleDate = dto.SettleDate,
                SettleCurrency = dto.SettlementCurrency,
                SettleAmount = (decimal?)dto.SettleAmount,
                ClearingAccount = dto.ClearingAccount,
                ClearingFirm = dto.ClearingFirm,
                CustomNote1 = dto.CustomNote1,
                CustomNote2 = dto.CustomNote2,
                CustomNote3 = dto.CustomNote3,
                CustomNote4 = dto.CustomNote4,
                CustomNote5 = dto.CustomNote5,
                Notes = dto.Notes,
                TraderUuid = dto.TraderUuid,
                Trader = dto.Trader,
                EmsxDate = dto.Date,
                PercentRemain = dto.PercentRemain,
                TimeStamp = dto.TimeStamp,
                YellowKey = dto.YellowKey,
                BrokerCommm = (decimal)dto.BrokerComm.GetValueOrDefault(),
                CommmRate = (decimal)dto.CommRate.GetValueOrDefault(),
                Principal = (decimal)dto.Principal.Value,
            };
        
        
        }

        public static TradeAllocationDto Map(this Entities.TradeAllocation entity)
        {
            return new TradeAllocationDto
            {
                TradeAllocationId = entity.TradeAllocationId,
                TradeId = entity.TradeId,
        
                PortfolioId = entity.PortfolioId,
                Quantity = entity.Quantity,
                Price = entity.Price,
                PositionSide = entity.PositionSide,
                TradingAccount = entity.TradingAccount,
                NetAmount = entity.NetAmount,
                GrossAmount = entity.GrossAmount,
                Commission = entity.Commission,
                Fees = entity.Fees
            };
        }
        public static IEnumerable<TradeAllocationDto> Map(this IEnumerable<Entities.TradeAllocation> entities)
        {
            return entities.Select(x => x.Map());
        }

        public static IEnumerable<TradeDto> Map(this IEnumerable<Entities.Trade> entities)
        {
            return entities.Select(x => x.Map());
        }
        public static TradeDto Map(this Trade entity)
        {
            return new TradeDto
            {
                TradeId = entity.TradeId,
                OrderId = entity.OrderId,
                RebalancingId = entity.RebalancingId,
                EmsxSequence = entity.EmsxSequence,
                EmsxOrderCreatedOn = entity.EmsxOrderCreatedOn,
                InstrumentId = entity.InstrumentId,
                ExchangeCode = entity.ExchangeCode,
                Sedol = entity.Sedol,
                BuySellIndicator = entity.BuySellIndicator,
                OrderQuantity = entity.OrderQuantity,
                FilledQuantity = entity.FilledQuantity,
                AvgPrice = entity.AvgPrice,
                DayAveragePrice = entity.DayAveragePrice,
                TradeCurrency = entity.TradeCurrency,
                TradeDate = entity.TradeDate,
                Principal = entity.Principal,
                NetAmount = entity.NetAmount,
                SettlementDate = entity.SettlementDate,
                SettlementCurrency = entity.SettlementCurrency,
                BrokerCommission = entity.BrokerCommission,
                CommissionRate = entity.CommissionRate,
                MiscFees = entity.MiscFees,
                Notes = entity.Notes,
                Trader = entity.Trader,
                BrokerCode = entity.BrokerCode,
                TradeDesk = entity.TradeDesk,
                IsCfd = entity.IsCfd,
                ExecutionChannel = entity.ExecutionChannel,
                CreatedOn = entity.CreatedOn,
                TotalCharges = entity.TotalCharges,
                FxemTradeId = entity.FxemTradeId,
                FxemOrderId = entity.FxemOrderId,
                TradeStatus = entity.TradeStatus,
                FxCurrency1 = entity.FxCurrency1,
                Fxcurrency1Amount = entity.Fxcurrency1Amount,
                FxCurrency2 = entity.FxCurrency2,
                Fxcurrency2Amount = entity.Fxcurrency2Amount,
                BookedOn = entity.BookedOn,
                TradeAllocations = entity.TradeAllocations.Map() // Assuming you have a list of TradeAllocation in your Trade entity.
            };
        }


    }
}
