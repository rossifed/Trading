using Quantaventis.Trading.Modules.Transmission.Api.Dto;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Transmission.Api.Mappers
{
    internal static class Extensions
    {

        internal static IEnumerable<BookedTradeAllocation> Map(this IEnumerable<BookedTradeDto> trades)
         => trades.SelectMany(x => x.Map()).ToList();
   
            internal static IEnumerable<BookedTradeAllocation> Map(this BookedTradeDto trade)
        {
            List<BookedTradeAllocation> entities = new List<BookedTradeAllocation>();
            foreach (BookedTradeAllocationDto allocDto in trade.TradeAllocations)
            {
                var entity = new BookedTradeAllocation()
                {
                    TradeAllocationId = allocDto.TradeAllocationId,
                    TradeId = allocDto.TradeId,
                    TradeStatus = allocDto.TradeStatus.ToString(),
                    InstrumentId = trade.InstrumentId,
                    Symbol = trade.Symbol,
                    TradeSide = trade.TradeSide,
                    Quantity = allocDto.Quantity,
                    NominalQuantity = allocDto.NominalQuantity,
                    LocalCurrency = allocDto.LocalCurrency,
                    TradeDate = trade.TradeDate,
                    Exchange = trade.Exchange,
                    OrderAllocationQuantity = allocDto.OrderAllocationQuantity,
                    EmsxOrderId = trade.EmsxOrderId,
                    BlockOrderQuantity = trade.OrderQuantity,
                    ExecutionType = trade.ExecutionType,
                    InstrumentType = trade.InstrumentType,
                    OrderReferenceId = trade.OrderReferenceId,
                    TraderName = trade.TraderName,
                    TraderUuid = trade.TraderUuid,
                    YellowKey = trade.YellowKey,
                    PriceScalingFactor = trade.PriceScalingFactor,
                    IsSwap = trade.IsSwap,
                    ContractMultiplier = allocDto.ContractMultiplier,
                    TradeInstrumentType = trade.TradeInstrumentType,
                    SettlementDate = allocDto.SettlementDate,
                    ExecutionBroker = trade.ExecutionBroker,
                    ExecutionDesk = trade.ExecutionDesk,
                    ExecutionAccount = trade.ExecutionAccount,
                    Isin = trade.Isin,
                    Sedol = trade.Sedol,
                    Cusip = trade.Cusip,
                    SecurityName = trade.SecurityName,
                    LocalExchangeSymbol = trade.LocalExchangeSymbol,
                    BaseCurrency = allocDto.BaseCurrency,
                    ClearingAccount = allocDto.ClearingAccount,
                    PortfolioId = allocDto.PortfolioId,
                    ClearingBroker = allocDto.ClearingBroker,
                    Custodian = allocDto.Custodian,
                    CommissionValue = allocDto.CommissionValue,
                    SettlementCurrency = allocDto.SettlementCurrency,
                    GrossAvgPriceBase = allocDto.GrossAvgPriceBase,
                    GrossAvgPriceLocal = allocDto.GrossAvgPriceLocal,
                    GrossPrincipalBase = allocDto.GrossPrincipalBase,
                    GrossPrincipalLocal = allocDto.GrossPrincipalLocal,
                    GrossPrincipalSettle = allocDto.GrossPrincipalSettle,
                    GrossTradeValueBase = allocDto.GrossTradeValueBase,
                    GrossTradeValueLocal = allocDto.GrossTradeValueLocal,
                    GrossTradeValueSettle = allocDto.GrossTradeValueSettle,
                    LocalToBaseFxRate = allocDto.LocalToBaseFxRate,
                    LocalToSettleFxRate = allocDto.LocalToSettleFxRate,
                    NetAvgPriceBase = allocDto.NetAvgPriceBase,
                    NetAvgPriceLocal = allocDto.NetAvgPriceLocal,
                    NetPrincipalBase = allocDto.NetPrincipalBase,
                    NetPrincipalLocal = allocDto.NetPrincipalLocal,
                    NetPrincipalSettle = allocDto.NetPrincipalSettle,
                    NetTradeValueBase = allocDto.NetTradeValueBase,
                    NetTradeValueLocal = allocDto.NetTradeValueLocal,
                    NetTradeValueSettle = allocDto.NetTradeValueSettle,
                    PositionSide = allocDto.PositionSide,
                    PrimeBroker = allocDto.PrimeBroker,
                    CommissionAmountBase = allocDto.CommissionAmountBase,
                    CommissionAmountLocal = allocDto.CommissionAmountLocal,
                    CommissionAmountSettle = allocDto.CommissionAmountSettle,
                    GrossAvgPriceSettle = allocDto.GrossAvgPriceSettle,
                    NetAvgPriceSettle = allocDto.NetAvgPriceSettle,
                    PriceCommissionBase = allocDto.PriceCommissionBase,
                    PriceCommissionLocal = allocDto.PriceCommissionLocal,
                    PriceCommissionSettle = allocDto.PriceCommissionSettle,
                    CommissionType = allocDto.CommissionType,
                    BookedOnUtc = trade.BookedOnUtc,
                    LastCorrectedOnUtc =allocDto.LastCorrectedOnUtc,
                    CanceledOnUtc = allocDto.CanceledOnUtc,
                };
                entities.Add(entity);
            }
            return entities;
        }

    }

}
