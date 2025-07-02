using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Entities=Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers
{
    internal static class Extensions
    {
        internal static IEnumerable<TradeBookingError> Map(this IEnumerable<Entities.TradeBookingError> entities)
                     => entities.Select(x => x.Map()).ToList();
        internal static TradeBookingError Map(this Entities.TradeBookingError entity)
        {

            return new TradeBookingError(entity.TradeId,
               Enum.Parse<BookingErrorType>(entity.ErrorType),
                entity.Message);
        }
        internal static IEnumerable<Entities.TradeBookingError> Map(this IEnumerable<TradeBookingError> errors)
                => errors.Select(x => x.Map()).ToList();
        internal static Entities.TradeBookingError Map(this TradeBookingError error)
        {

            return new Entities.TradeBookingError()
            {
                TradeId = error.TradeId,
                Message = error.Message,
                ErrorType = error.BookingErrorType.ToString(),

            };
        }

        internal static Instrument Map(this Entities.Instrument entity)
        {

            return new Instrument(entity.InstrumentId,
                entity.Symbol,
                entity.Name,
                entity.FuturePointValue,
                entity.InstrumentType,
                entity.MarketSector,
                entity.GenericFutureId,
                entity.PriceScalingFactor);
        }

        internal static Counterparty Map(this Entities.Counterparty entity)
        {

            return new Counterparty(entity.CounterpartyId, entity.Code, entity.Name);
        }
        internal static ExecutionDesk Map(this Entities.ExecutionDesk entity)
        {

            return new ExecutionDesk(entity.ExecutionDeskId, entity.Code, entity.ExecutionBroker.Map());
        }

        internal static ExecutionType Map(this Entities.ExecutionType entity)
        {

            return new ExecutionType(entity.ExecutionTypeId, entity.Code);
        }

        internal static Portfolio Map(this Entities.Portfolio entity)
        {

            return new Portfolio(entity.PortfolioId, entity.Currency);
        }

       

        //internal static IEnumerable<Position> Map(this IEnumerable<Entities.Position> tradeAllocations)
        //             => tradeAllocations.Select(x => x.Map());
        internal static CounterpartyRoleSetup Map(this Entities.CounterpartyRoleSetup entity)
        {

            return new CounterpartyRoleSetup(entity.CounterpartyRoleSetupId,
                entity.PrimeBroker?.Map(),
                entity.ClearingBroker.Map(),
                entity.Custodian?.Map());
        }
        internal static SettlementInfo Map(this Entities.SettlementInfo entity)
        {

            return new SettlementInfo(entity.SettleCurrency,
                entity.DaysToSettle);
        }

        internal static Account Map(this Entities.ClearingAccount entity)
        {

            return new Account(entity.Code);
        }

        internal static CommissionType Map(this Entities.CommissionType entity)
        {

            return Enum.Parse<CommissionType>(entity.Code);
        }
        internal static Commission MapToCommission(this Entities.CommissionSchedule entity)
        {

            return new Commission(entity.CommissionValue, entity.CommissionType.Map());
        }
        internal static FxRate Map(this Entities.FxRate entity)
        {

            return new FxRate(entity.Value, entity.BaseCurrency, entity.QuoteCurrency);
        }

        internal static TradeInstrumentType Map(this Entities.TradeInstrumentType entity)
        {

            return new TradeInstrumentType(entity.TradeInstrumentTypeId,
                entity.Mnemonic,
                entity.Name,
                entity.InstrumentType,
                entity.IsSwap);
        }

        internal static IEnumerable<Entities.RawTradeAllocation> Map(this IEnumerable<RawTradeAllocation> tradeAllocations)
            => tradeAllocations.Select(x => x.Map()).ToList();
        internal static IEnumerable<RawTradeAllocation> Map(this IEnumerable<Entities.RawTradeAllocation> errors)
           => errors.Select(x => x.Map()).ToList();
        internal static RawTradeAllocation Map(this Entities.RawTradeAllocation entity)
        {

            return new RawTradeAllocation(
                entity.TradeAllocationId,
                entity.TradeId,
                entity.PortfolioId,
                entity.AllocatedQuantity,
                entity.OrderAllocationQuantity,
                entity.PositionSide);
        }
        internal static Entities.RawTradeAllocation Map(this RawTradeAllocation tradeAllocation)
        {
            return new Entities.RawTradeAllocation()
            { 
                TradeAllocationId = tradeAllocation.Id,
                PortfolioId = tradeAllocation.PortfolioId,
                AllocatedQuantity = (int)tradeAllocation.Quantity,
                TradeId = tradeAllocation.TradeId,
                OrderAllocationQuantity = (int)tradeAllocation.OrderAllocationQuantity,
                PositionSide = tradeAllocation.PositionSide.ToString()
            };
        }
        internal static IEnumerable<Entities.TradeAllocation> Map(this IEnumerable<BookedTradeAllocation> bookedTradeAllocations) {
            return bookedTradeAllocations.Select(x => x.Map()).ToList(); ;    
        }
        

            internal static Entities.TradeAllocation Map(this BookedTradeAllocation bookedTradeAllocation)
        {
            var tradeAllocation = bookedTradeAllocation.EnrichedTradeAllocation;
            return new Entities.TradeAllocation()
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
                MiscFeesBase = tradeAllocation.MiscFeesAmountBase.Amount,
                MiscFeesLocal = tradeAllocation.MiscFeesAmountLocal.Amount,
                MiscFeesSettle = tradeAllocation.MiscFeesAmountSettle.Amount,
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
                 OrderAllocationNominalQuantity = tradeAllocation.OrderAllocationNominalQuantity,
                
 
                NominalQuantity = tradeAllocation.NominalQuantity,
            
                CommissionType = tradeAllocation.CommissionType.ToString(),
                TradeId = tradeAllocation.TradeId,
            };
        }

        internal static Entities.RawTrade Map(this RawTrade trade)
        {
            return new Entities.RawTrade()
            {
                TradeId = trade.TradeId,
                Symbol = trade.Symbol,
                Side = trade.Side,
                Quantity = trade.Quantity,
                AvgPrice = trade.AvgPrice,
                Currency = trade.Currency,
                TradeDate = trade.TradeDate.ToDateTime(TimeOnly.MinValue),
                Exchange = trade.Exchange,
                ExecutionDesk = trade.ExecutionDesk,
                ExecutionBroker = trade.ExecutionDesk,
                ExecutionAccount = trade.ExecutionAccount,
                IsCfd = trade.IsCfd,
                Cusip = trade.InstrumentIdentifiers. Cusip,
                Isin = trade.InstrumentIdentifiers.Isin,
                Sedol = trade.InstrumentIdentifiers.Sedol,
                SecurityName = trade.InstrumentIdentifiers.SecurityName,
                LocalExchangeSymbol = trade.InstrumentIdentifiers.LocalExchangeSymbol,
                EmsxOrderId = trade.EmsxOrderId,
                OrderReferenceId = trade.OrderReferenceId,
                OrderQuantity = trade.OrderDetails. OrderQuantity,
                OrderType = trade.OrderDetails.OrderType,
                StrategyType = trade.StrategyType,
                Tif = trade.OrderDetails.TimeInForce,
                OrderExecutionInstruction = trade.OrderDetails.OrderExecutionInstruction,
                OrderHandlingInstruction = trade.OrderDetails.OrderHandlingInstruction,
                OrderInstruction = trade.OrderDetails.OrderInstruction,
                LimitPrice = trade.OrderDetails.LimitPrice,
                StopPrice = trade.OrderDetails.StopPrice,
                OriginatingTraderUuid = trade.OrderDetails.OriginatingTraderUUId,
                TraderName = trade.OrderDetails.TraderName,
                TraderUuid = trade.OrderDetails.TraderUuid,
                SettlementDate = trade.SettlementDate?.ToDateTime(TimeOnly.MinValue),
                UserCommissionAmount = trade.OrderDetails.UserCommissionAmount,
                UserCommissionRate = trade.OrderDetails.UserCommissionRate,
                UserFees = trade.OrderDetails.UserFees,
                UserNetMoney = trade.OrderDetails.UserNetMoney,
                YellowKey = trade.InstrumentIdentifiers.YellowKey,
                ExecutionChannel = trade.ExecutionChannel,
                NumberOfFills = trade.FillsDetails.NumberOfFills,
                FirstFillTimeUtc = trade.FillsDetails.FirstFillDateTimeUtc,
                LastFillTimeUtc = trade.FillsDetails.LastFillDateTimeUtc,
                MaxFillPrice = trade.FillsDetails.MaxFillPrice,
                MinFillPrice = trade.FillsDetails.MinFillPrice
            };
        }

        internal static IEnumerable<BookedTrade> Map(this IEnumerable<Entities.Trade> entities)
        {
            return entities.Select(x => x.Map()).ToList(); ;
        }

        internal static BookedTrade Map(this Entities.Trade entity) {
            return new BookedTrade(
                entity.MapEnrichedTrade(),
                entity.TradeAllocations.Map(),
                Enum.Parse<TradeStatus>( entity.TradeStatus),
                entity.BookedOnUtc,
                entity.LastCorrectedOnUtc,
                entity.CanceledOnUtc

                ); 
        }
        internal static IEnumerable<BookedTradeAllocation> Map(this IEnumerable<Entities.TradeAllocation> entities)
        {
           return entities.Select(x => x.Map()).ToList();
        }
        internal static BookedTradeAllocation Map(this Entities.TradeAllocation entity)
        {

            return 
                
                new BookedTradeAllocation(
                new EnrichedTradeAllocation(
                    entity.TradeAllocationId,
                       entity.TradeId,
                       entity.PortfolioId,
                       entity.BaseCurrency,
                       Enum.Parse<PositionSide>( entity.PositionSide),
                       entity.Quantity,
                       entity.OrderAllocationQuantity,
                       entity.GrossAvgPriceLocal,
                       entity.ContractMultiplier,
                       new Commission(entity.CommissionValue,entity.CommissionType),
                       entity.LocalCurrency,
                       entity.LocalToBaseFxRate,
                       entity.LocalToSettleFxRate,
                       new TradeSettlement(entity.SettlementCurrency,entity.SettlementDate),
                       entity.ClearingBroker,
                       entity.Custodian,
                       entity.PrimeBroker,
                       entity.ClearingAccount
                ),
                Enum.Parse<TradeStatus>(entity.TradeStatus),
 
                entity.LastCorrectedOnUtc,
                entity.CanceledOnUtc             
                );
        }

            internal static EnrichedTrade MapEnrichedTrade(this Entities.Trade entity)
        {
            return new EnrichedTrade(entity.TradeId,
                entity.RebalancingId,
                entity.TradeSide,
                entity.InstrumentId,
                entity.TradeQuantity,
                new Money(entity.AvgPrice, entity.TradeCurrency),
                DateOnly.FromDateTime(entity.TradeDate),
                entity.InstrumentType,
                entity.TradeInstrumentType,
                entity.IsSwap,
                entity.Exchange,
                entity.ExecutionChannel,
                entity.ExecutionDesk,
                entity.ExecutionBroker,
                entity.ExecutionAccount,
                entity.ExecutionType,
                entity.ContractMultiplier,
                entity.SettlementDate.ToNullableDateOnly(),
                entity.PriceScalingFactor,
             new InstrumentIdentifiers(
                 entity.Symbol,
                 entity.Isin,
           
               entity.Sedol,
               entity.Cusip,
               entity.SecurityName,
               entity.LocalExchangeSymbol,
               entity.YellowKey),
               new OrderDetails(entity.EmsxOrderId,
               entity.OrderReferenceId,
               entity.OrderQuantity,
               entity.OrderType,
               entity.StrategyType,
               entity.TimeInForce,
               entity.OrderExecutionInstruction,
               entity.OrderHandlingInstruction,
               entity.OrderInstruction,
               entity.LimitPrice,
               entity.StopPrice,
               entity.OriginatingTraderUuid,
               entity.TraderName,
               entity.TraderUuid,
               entity.UserCommissionAmount,
               entity.UserCommissionRate,
               entity.UserFees,
               entity.UserNetMoney),
               new FillsDetails(entity.NumberOfFills,
               entity.FirstFillTimeUtc,
               entity.LastFillTimeUtc,
               entity.MaxFillPrice,
               entity.MinFillPrice));
             
        }

  
            internal static Entities.Trade Map(this BookedTrade trade)
        {
            var entity =  new Entities.Trade()
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
         
                IsSwap = trade.EnrichedTrade.IsSwap,

                ExecutionChannel = trade.EnrichedTrade.ExecutionChannel,
                RebalancingId = trade.EnrichedTrade.RebalancingId,
                ContractMultiplier = trade.EnrichedTrade.ContractMultiplier,
              
                Principal = trade.EnrichedTrade.Principal.Amount,
               
                TradeValue = trade.EnrichedTrade.TradeValue.Amount,
                AvgPrice = trade.EnrichedTrade.AvgPrice.Amount,
                ExecutionType = trade.EnrichedTrade.ExecutionType,
                InstrumentType = trade.EnrichedTrade.InstrumentType,
                TradeInstrumentType = trade.EnrichedTrade.TradeInstrumentType,
                SettlementDate = trade.EnrichedTrade.SettlementDate.ToNullableDateTime(),
                
                
                ExecutionBroker = trade.EnrichedTrade.ExecutionBroker,
                ExecutionDesk = trade.EnrichedTrade.ExecutionDesk,
                ExecutionAccount = trade.EnrichedTrade.ExecutionAccount,
                Isin = trade.EnrichedTrade.InstrumentIdentifiers.Isin,
                Sedol = trade.EnrichedTrade.InstrumentIdentifiers.Sedol,
                Cusip = trade.EnrichedTrade.InstrumentIdentifiers.Cusip,
                YellowKey = trade.EnrichedTrade.InstrumentIdentifiers.YellowKey,
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
                PriceScalingFactor = trade.EnrichedTrade.PriceScalingFactor,

            };

            foreach (var item in trade.BookedTradeAllocations)
            {
                entity.TradeAllocations.Add(item.Map());
            }
            return entity;
        }
        internal static DateOnly? ToNullableDateOnly(this DateTime? dateTime)
            => dateTime == null ? null : DateOnly.FromDateTime(dateTime.Value);
        internal static TimeOnly? ToNullableTimeOnly(this DateTime? dateTime)
        => dateTime == null ? null : TimeOnly.FromDateTime(dateTime.Value);
        internal static DateTime ToDateTime(this DateOnly dateOnly)
      => dateOnly.ToDateTime(TimeOnly.MinValue);
        internal static DateTime? ToNullableDateTime(this DateOnly? dateOnly)
            => dateOnly == null ? null : dateOnly.Value.ToDateTime(TimeOnly.MinValue);
        internal static IEnumerable<Order> Map(this IEnumerable<Entities.Order> entities)
        {
            return entities.Select(x => x.Map());
        }

        internal static IEnumerable<Entities.Order> Map(this IEnumerable<Order> entities)
        {
            return entities.Select(x => x.Map());
        }
        internal static Order Map(this Entities.Order entity)
        {
            return new Order(entity.OrderId,
                entity.RebalancingId,
                entity.InstrumentId,
                 entity.Symbol,
                entity.Quantity,
                DateOnly.FromDateTime(entity.TradeDate),
                entity.TradeMode,
                entity.OrderType,
                entity.ExecutionAlgo,
                entity.TimeInForce,
                entity.ExecutionDesk,
                entity.ExecutionAccount,
                entity.OrderAllocations.Map());
        }

        internal static Entities.Order Map(this Order order)
        {
            var entity = new Entities.Order()
            {
                OrderId = order.Id,
                InstrumentId = order.InstrumentId,
                Quantity = order.Quantity,
                RebalancingId = order.RebalancingId,
                Symbol = order.Symbol,
          
                TradeDate = order.TradeDate.ToDateTime(),
                TradeMode=  order.TradeMode,
                OrderType= order.OrderType,
                ExecutionAlgo = order.ExecutionAlgo,
                TimeInForce = order.TimeInForce,
                ExecutionDesk = order.ExecutionDesk,
                ExecutionAccount = order.ExectionAccount,

            };
            order.OrderAllocations.ToList().ForEach(x => entity.OrderAllocations.Add(x.Map()));
            return entity;
        }

        internal static Entities.OrderAllocation Map(this OrderAllocation orderAlloc)
        {
            return new Entities.OrderAllocation()
            {
                OrderId = orderAlloc.OrderId,
                PortfolioId = orderAlloc.PortfolioId,
                Quantity = orderAlloc.Quantity,
                PositionSide = orderAlloc.PositionSide.ToString(),

            };
          
        }


        internal static OrderAllocation Map(this Entities.OrderAllocation entity)
        {
            return new OrderAllocation(entity.OrderId,
         
                entity.PortfolioId, 
                entity.Quantity, 
                entity.PositionSide);

        }

        internal static IEnumerable<OrderAllocation> Map(this IEnumerable<Entities.OrderAllocation> entities)
        {
            return entities.Select(x => x.Map()).ToList();
        }

        internal static IEnumerable<RawTrade> Map(this IEnumerable<Entities.RawTrade> entities)
        {
            return entities.Select(x => x.Map()).ToList();
        }
        internal static RawTrade Map(this Entities.RawTrade entity)
        {
            return new RawTrade(entity.TradeId,
                 entity.Symbol,
                entity.Side,
                entity.Quantity,
               entity.AvgPrice,
               entity.Currency,
                DateOnly.FromDateTime(entity.TradeDate),
               entity.Exchange,
               entity.ExecutionBroker,
               entity.ExecutionAccount,
               entity.IsCfd,
               entity.ExecutionChannel,
              
               entity.SettlementDate.ToNullableDateOnly(),
     
               new InstrumentIdentifiers(
                   entity.Symbol,
                   entity.Isin,
               entity.Sedol,
               entity.Cusip,
               entity.SecurityName,
               entity.LocalExchangeSymbol,
               entity.YellowKey),
               new OrderDetails(entity.EmsxOrderId,
               entity.OrderReferenceId,
               entity.OrderQuantity,
               entity.OrderType,
               entity.StrategyType,
               entity.Tif,
               entity.OrderExecutionInstruction,
               entity.OrderHandlingInstruction,
               entity.OrderInstruction,
               entity.LimitPrice,
               entity.StopPrice,
               entity.OriginatingTraderUuid,
               entity.TraderName,
               entity.TraderUuid,
               entity.UserCommissionAmount,
               entity.UserCommissionRate,
               entity.UserFees,
               entity.UserNetMoney),
               new FillsDetails(entity.NumberOfFills,
               entity.FirstFillTimeUtc,
               entity.LastFillTimeUtc,
               entity.MaxFillPrice,
               entity.MinFillPrice)
               )
            {

               
                SettlementDate = entity.SettlementDate.ToNullableDateOnly(),
               

            };
        }
    }
}
