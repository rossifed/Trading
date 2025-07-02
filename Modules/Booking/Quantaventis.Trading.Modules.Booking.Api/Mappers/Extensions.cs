using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Api.Dto;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;
using Entities = Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Booking.Api.Mappers
{
    internal static class Extensions
    {
        internal static IEnumerable<Order> Map(this IEnumerable<OrderDto> dtos)
            => dtos.Select(x => x.Map()).ToList();

        internal static IEnumerable<OrderAllocation> Map(this IEnumerable<OrderAllocationDto> dtos, int orderId)
       => dtos.Select(x => x.Map(orderId)).ToList();

        internal static OrderAllocation Map(this OrderAllocationDto dto, int orderId)
        {
            return new OrderAllocation(orderId, dto.PortfolioId, dto.Quantity, dto.PositionSide);
        }
        internal static Order Map(this OrderDto dto)
        {
            return new Order(dto.OrderId,

                dto.RebalancingSessionId,
                dto.InstrumentId,
                dto.Symbol,
                dto.Quantity,
                dto.TradeDate,
                dto.TradeMode,
                dto.OrderType,
                dto.ExecutionAlgorithm,
                dto.TimeInForce,
                dto.TradingDesk,
                dto.OrderAllocations.Select(x => x.TradingAccount).Distinct().FirstOrDefault(""),//TODO:The exec account must be defined at level of order. this is a hack before modification in ord module


                dto.OrderAllocations.Map(dto.OrderId)); ;
        }

        internal static TradeCorrection Map(this TradeCorrectionDto dto)
        {
            return new TradeCorrection(dto.AvgPriceLocal,
                dto.TradeInstrumentType,
                dto.IsSwap,
                dto.ContractMultiplier,
                dto.ExecutionBroker,
                dto.ExecutionAccount,
                dto.Exchange,
                dto.ExecutionType,
                dto.TradeDate);
        }
        internal static TradeCorrectionDto Map(this TradeCorrection domain)
        {
            return new TradeCorrectionDto()
            {
                AvgPriceLocal = domain.AvgPriceLocal,
                TradeInstrumentType = domain.TradeInstrumentType,
                IsSwap = domain.IsSwap,
                ContractMultiplier = domain.ContractMultiplier,
                ExecutionBroker = domain.ExecutionBroker,
                ExecutionAccount = domain.ExecutionAccount,
                Exchange = domain.Exchange,
                ExecutionType = domain.ExecutionType,
                TradeDate = domain.TradeDate
            };
        }
        internal static IEnumerable<BookedTradeDto> Map(this IEnumerable<BookedTrade> trades)
         => trades.Select(x => x.Map()).ToList();
            internal static BookedTradeDto Map(this BookedTrade trade)
        {
            return new BookedTradeDto()
            {
                TradeId = trade.EnrichedTrade.TradeId,
                TradeStatus = trade.TradeStatus.ToString(),
                InstrumentId = trade.EnrichedTrade.InstrumentId,
                Symbol = trade.EnrichedTrade.Symbol,
                TradeSide = trade.EnrichedTrade.TradeSide,
                TradeQuantity = trade.EnrichedTrade.Quantity.ToInt32(),
                NominalQuantity = trade.EnrichedTrade.NominalQuantity,
                TradeCurrency = trade.EnrichedTrade.TradeCurrency,
                TradeDate = trade.EnrichedTrade.TradeDate.ToDateTime(),
                Exchange = trade.EnrichedTrade.Exchange,
                PriceScalingFactor = trade.EnrichedTrade.PriceScalingFactor,
                IsSwap = trade.EnrichedTrade.IsSwap,
               
                ExecutionChannel = trade.EnrichedTrade.ExecutionChannel,
                RebalancingId = trade.EnrichedTrade.RebalancingId,
                ContractMultiplier = trade.EnrichedTrade.ContractMultiplier,

                Principal = trade.EnrichedTrade.Principal.Amount,

                TradeValue = trade.EnrichedTrade.TradeValue.Amount,
                AvgPrice = trade.EnrichedTrade.AvgPrice.Amount,
                ExecutionType = trade.EnrichedTrade.ExecutionType,
                TradeInstrumentType = trade.EnrichedTrade.TradeInstrumentType,
                SettlementDate = trade.EnrichedTrade.SettlementDate.ToNullableDateTime(),
                InstrumentType = trade.EnrichedTrade.InstrumentType,
                YellowKey = trade.EnrichedTrade.InstrumentIdentifiers.YellowKey,
               

                ExecutionBroker = trade.EnrichedTrade.ExecutionBroker,
                ExecutionDesk = trade.EnrichedTrade.ExecutionDesk,
                ExecutionAccount = trade.EnrichedTrade.ExecutionAccount,
                Isin = trade.EnrichedTrade.InstrumentIdentifiers.Isin,
                Sedol = trade.EnrichedTrade.InstrumentIdentifiers.Sedol,
                Cusip = trade.EnrichedTrade.InstrumentIdentifiers.Cusip,
                SecurityName = trade.EnrichedTrade.InstrumentIdentifiers.SecurityName,
                LocalExchangeSymbol = trade.EnrichedTrade.InstrumentIdentifiers.LocalExchangeSymbol,
                EmsxOrderId = trade.EnrichedTrade.OrderDetails.EmsxOrderId,
                OrderReferenceId = trade.EnrichedTrade.OrderDetails.OrderReferenceId,
                OrderQuantity = trade.EnrichedTrade.OrderDetails.OrderQuantity,
                OrderType = trade.EnrichedTrade.OrderDetails.OrderType,
                StrategyType = trade.EnrichedTrade.OrderDetails.StrategyType,
                TimeInForce = trade.EnrichedTrade.OrderDetails.TimeInForce,
                OrderExecutionInstruction = trade.EnrichedTrade.OrderDetails.OrderExecutionInstruction,
                OrderHandlingInstruction = trade.EnrichedTrade.OrderDetails.OrderHandlingInstruction,
                OrderInstruction = trade.EnrichedTrade.OrderDetails.OrderInstruction,
                LimitPrice = trade.EnrichedTrade.OrderDetails.LimitPrice,
                StopPrice = trade.EnrichedTrade.OrderDetails.StopPrice,
                OriginatingTraderUuid = trade.EnrichedTrade.OrderDetails.OriginatingTraderUUId,
                TraderName = trade.EnrichedTrade.OrderDetails.TraderName,
                TraderUuid = trade.EnrichedTrade.OrderDetails.TraderUuid,
                UserCommissionAmount = trade.EnrichedTrade.OrderDetails.UserCommissionAmount,
                UserCommissionRate = trade.EnrichedTrade.OrderDetails.UserCommissionRate,
                UserFees = trade.EnrichedTrade.OrderDetails.UserFees,
                UserNetMoney = trade.EnrichedTrade.OrderDetails.UserNetMoney,
                NumberOfFills = trade.EnrichedTrade.FillsDetails.NumberOfFills,
                FirstFillTimeUtc = trade.EnrichedTrade.FillsDetails.FirstFillDateTimeUtc,
                LastFillTimeUtc = trade.EnrichedTrade.FillsDetails.LastFillDateTimeUtc,
                MaxFillPrice = trade.EnrichedTrade.FillsDetails.MaxFillPrice,
                MinFillPrice = trade.EnrichedTrade.FillsDetails.MinFillPrice,
                BookedOnUtc = trade.BookingDateUtc,
                LastCorrectedOnUtc = trade.LastCorrectionDateUtc,
                CanceledOnUtc = trade.CancelationDateUtc,
                TradeAllocations = trade.BookedTradeAllocations.Map()
            };

           
   
        }
        internal static IEnumerable<BookedTradeAllocationDto> Map(this IEnumerable<BookedTradeAllocation> allocations)
                 => allocations.Select(x => x.Map()).ToList();
        internal static BookedTradeAllocationDto Map(this BookedTradeAllocation bookedTradeAllocation)
        {
           
                var tradeAllocation = bookedTradeAllocation.EnrichedTradeAllocation;
                return new BookedTradeAllocationDto()
                {
                    TradeAllocationId = tradeAllocation.TradeAllocationId,
                    PortfolioId = tradeAllocation.PortfolioId,
                    Quantity = tradeAllocation.Quantity.ToInt32(),
                    BaseCurrency = tradeAllocation.PortfolioCurrency,
                    ClearingAccount = tradeAllocation.ClearingAccount,
                    ClearingBroker = tradeAllocation.ClearingBroker,
                    Custodian = tradeAllocation.Custodian,
                    LocalCurrency = tradeAllocation.TradeCurrency,
                    OrderAllocationQuantity = tradeAllocation.OrderAllocationQuantity,
                    
                    CanceledOnUtc = bookedTradeAllocation.CanceledOnUtc,
                    CommissionValue = tradeAllocation.CommissionValue,
                    ContractMultiplier = tradeAllocation.ContractMultiplier,
                    LastCorrectedOnUtc = bookedTradeAllocation.LastCorrectedOnUtc,
                    SettlementCurrency = tradeAllocation.SettlementCurrency,
                    SettlementDate = tradeAllocation.SettlementDate.ToDateTime(),
                    TradeStatus = bookedTradeAllocation.TradeStatus.ToString(),
                    GrossAvgPriceBase = tradeAllocation.GrossAvgPriceBase.Amount,
                    GrossAvgPriceLocal = tradeAllocation.GrossAvgPriceLocal.Amount,
                    GrossPrincipalBase = tradeAllocation.GrossPrincipalBase.Amount,
                    GrossPrincipalLocal = tradeAllocation.GrossPrincipalLocal.Amount,
                    GrossPrincipalSettle = tradeAllocation.GrossPrincipalSettle.Amount,
                    GrossTradeValueBase = tradeAllocation.GrossTradeValueBase.Amount,
                    GrossTradeValueLocal = tradeAllocation.GrossTradeValueLocal.Amount,
                    GrossTradeValueSettle = tradeAllocation.GrossTradeValueSettle.Amount,
                    LocalToBaseFxRate = tradeAllocation.LocalToBaseFxRate.Value,
                    LocalToSettleFxRate = tradeAllocation.LocalToSettleFxRate.Value,
                    NetAvgPriceBase = tradeAllocation.NetAvgPriceBase.Amount,
                    NetAvgPriceLocal = tradeAllocation.NetAvgPriceLocal.Amount,
                    NetPrincipalBase = tradeAllocation.NetPrincipalBase.Amount,
                    NetPrincipalLocal = tradeAllocation.NetPrincipalLocal.Amount,
                    NetPrincipalSettle = tradeAllocation.NetPrincipalSettle.Amount,
                    NetTradeValueBase = tradeAllocation.NetTradeValueBase.Amount,
                    NetTradeValueLocal = tradeAllocation.NetTradeValueLocal.Amount,
                    NetTradeValueSettle = tradeAllocation.NetTradeValueSettle.Amount,
                    PositionSide = tradeAllocation.PositionSide.ToString(),
                    PrimeBroker = tradeAllocation.PrimeBroker,
                    CommissionAmountBase = tradeAllocation.CommissionAmountBase.Amount,
                    CommissionAmountLocal = tradeAllocation.CommissionAmountLocal.Amount,
                    CommissionAmountSettle = tradeAllocation.CommissionAmountSettle.Amount,
                    GrossAvgPriceSettle = tradeAllocation.GrossAvgPriceSettle.Amount,
                    NetAvgPriceSettle = tradeAllocation.NetAvgPriceSettle.Amount,
                    PriceCommissionBase = tradeAllocation.PriceCommissionBase.Amount,
                    PriceCommissionLocal = tradeAllocation.PriceCommissionLocal.Amount,
                    PriceCommissionSettle = tradeAllocation.PriceCommissionSettle.Amount,
                    MiscFeesAmountBase = tradeAllocation.MiscFeesAmountBase.Amount,
                    MiscFeesAmountLocal = tradeAllocation.MiscFeesAmountLocal.Amount,
                    MiscFeesAmountSettle = tradeAllocation.MiscFeesAmountSettle.Amount,
                    

                    NominalQuantity = tradeAllocation.NominalQuantity,

                    CommissionType = tradeAllocation.CommissionType.ToString(),
                    TradeId = tradeAllocation.TradeId,
                };
            
        }
        internal static TradeAllocationCorrection Map(this TradeAllocationCorrectionDto dto)
        {
            return new TradeAllocationCorrection(
                dto.PositionSide,
                dto.AvgPriceLocal,
                dto.ContractMultiplier,
                dto.CommissionValue,
                dto.CommissionType,
                dto.LocalToBaseFxRate,
                dto.LocalToSettleFxRate,
                dto.SettlementDate,
                dto.SettlementCurrency,
                dto.ClearingBroker,
                dto.Custodian,
                dto.PrimeBroker,
                dto.ClearingAccount
                );
        }
        internal static TradeAllocationCorrectionDto Map(this TradeAllocationCorrection dto)
        {
            return new TradeAllocationCorrectionDto() {
                PositionSide = dto.PositionSide?.ToString(),
                AvgPriceLocal = dto.AvgPriceLocal,
                ContractMultiplier = dto.ContractMultiplier,
                CommissionValue = dto.CommissionValue,
                CommissionType = dto.CommissionType,
                LocalToBaseFxRate = dto.LocalToBaseFxRate,
                LocalToSettleFxRate = dto.LocalToSettleFxRate,
                SettlementDate= dto.SettlementDate,
                SettlementCurrency=dto.SettlementCurrency,
                ClearingBroker= dto.ClearingBroker,
                Custodian= dto.Custodian,
                PrimeBroker= dto.PrimeBroker,
                ClearingAccount=dto.ClearingAccount
                };
        }


        internal static RawTrade Map(this EmsxTradeDto dto)
        {
            return new RawTrade(0,
                  dto.Symbol,
                 dto.Side,
                 dto.FilledQuantity,
                dto.AvgPrice,
                dto.Currency,
                DateOnly.FromDateTime(dto.FirstFillDateTimeUtc),
                dto.Exchange,
                dto.Broker,
                dto.Account,
                dto.IsCFD, 
                "EMSX",
                dto.SettlementDate,
                 new InstrumentIdentifiers(
                     dto.Symbol,
                     dto.Isin,

               dto.Sedol,
               dto.Cusip,
               dto.SecurityName,
               dto.LocalExchangeSymbol,
               dto.YellowKey),
               new OrderDetails(dto.EmsxOrderId,
               Convert.ToInt32(dto.OrderReferenceId),
               dto.OrderQuantity,
               dto.OrderType,
               dto.StrategyType,
               dto.Tif,
               dto.OrderExecutionInstruction,
               dto.OrderHandlingInstruction,
               dto.OrderInstruction,
               dto.LimitPrice,
               dto.StopPrice,
               dto.OriginatingTraderUUId,
               dto.TraderName,
               dto.TraderUUId,
               dto.UserCommissionAmount,
               dto.UserCommissionRate,
               dto.UserFees,
               dto.UserNetMoney),
               new FillsDetails(
                   dto.NumberOfFills,
                    dto.FirstFillDateTimeUtc,
                    dto.LastFillDateTimeUtc,
                    dto.MaxFillPrice,
                    dto.MinFillPrice
                    ))
            {
               
               
            };


        }

        internal static RawTrade Map(this EfrpTradeDto dto, Order order)
        {
            return new RawTrade(0,
                  dto.BloombergSymbol,
                 dto.ClientSide,
                 dto.Quantity,
                dto.AvgPrice,
                dto.Ccy1,
                dto.TradeDate,
                dto.Exchange,
                order.ExecutionDesk,
                order.ExectionAccount,
                false,
                "EFRP",
                null,
                 new InstrumentIdentifiers(
                     dto.BloombergSymbol,
                     null,

               null,
               null,
               null,
               dto.ExchangeSymbol,
               "Curncy"),
               new OrderDetails(null,
               order.Id,
               order.Quantity,
               order.OrderType,
               order.ExecutionAlgo,
               order.TimeInForce,
               null,
               null,
               null,
               null,
               null,
               null,
               null,
               null,
               null,
               null,
               null,
               null),
               new FillsDetails(
                    dto.NumberOfDeals,
                    dto.FirstDealEntryTimeUtc,
                    dto.LastDealEntryTimeUtc,
                    dto.MaxDealPrice,
                    dto.MinDealPrice
                    ))
            {


            };


        }

    }

}
