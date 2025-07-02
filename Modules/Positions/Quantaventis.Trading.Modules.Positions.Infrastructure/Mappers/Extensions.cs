
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Positions.Domain.Model;
using Entities = Quantaventis.Trading.Modules.Positions.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Positions.Infrastructure.Mappers
{
    internal static class Extensions
    {
        public static IEnumerable<Entities.TradeAllocation> Map(this IEnumerable<TradeAllocation> allocations)
        {
            return allocations.Select(x => x.Map());


        }
        public static IEnumerable<TradeAllocation> Map(this IEnumerable<Entities.TradeAllocation> allocations)
        {
            return allocations.Select(x => x.Map());


        }

        public static TradeAllocation Map(this Entities.TradeAllocation entity)
        {
            return new TradeAllocation(entity.TradeAllocationId,
            entity.TradeId,
       entity.PortfolioId,
       entity.Quantity,
       entity.NominalQuantity,
       new InvestedInstrument(entity.InstrumentId,entity.IsSwap),
       DateOnly.FromDateTime(entity.TradeDate),
       entity.GrossAvgPriceLocal,
       entity.GrossAvgPriceBase,
       entity.NetAvgPriceLocal,
       entity.NetAvgPriceBase,
       entity.GrossTradeValueLocal,
       entity.GrossTradeValueBase,
       entity.NetTradeValueLocal,
       entity.NetTradeValueBase,
       entity.GrossPrincipalLocal,
       entity.GrossPrincipalBase,
       entity.NetPrincipalLocal,
       entity.NetPrincipalBase,
       entity.CommissionAmountLocal,
       entity.CommissionAmountBase,
       entity.LocalCurrency,
       entity.BaseCurrency,
       entity.LocalToBaseFxRate);
            


        }
        public static Entities.TradeAllocation Map(this TradeAllocation alloc)
        {
            return new Entities.TradeAllocation()
            {
                LocalCurrency = alloc.LocalCurrency,
                BaseCurrency = alloc.BaseCurrency,
                CommissionAmountBase = alloc.CommissionAmountBase.Amount,
                CommissionAmountLocal = alloc.CommissionAmountLocal.Amount,
                GrossAvgPriceLocal = alloc.GrossAveragePriceLocal.Amount,
                GrossAvgPriceBase = alloc.GrossAveragePriceBase.Amount,
                NetAvgPriceLocal = alloc.NetAveragePriceLocal.Amount,
                NetAvgPriceBase = alloc.NetAveragePriceBase.Amount,
                GrossTradeValueLocal = alloc.GrossTradeValueLocal.Amount,
                GrossTradeValueBase = alloc.GrossTradeValueBase.Amount,
                InstrumentId = alloc.InstrumentId,
                IsSwap = alloc.IsSwap,
                TradeId = alloc.TradeId,
                Quantity = alloc.Quantity,
                
                LocalToBaseFxRate = alloc.LocalToBaseFxRate.Value,
                TradeDate = alloc.TradeDate.ToDateTime(TimeOnly.MinValue),

                NominalQuantity = alloc.NominalQuantity,
                GrossPrincipalLocal = alloc.GrossPrincipalLocal.Amount,
                GrossPrincipalBase = alloc.GrossPrincipalBase.Amount,
                NetPrincipalBase = alloc.NetPrincipalBase.Amount,
                NetPrincipalLocal = alloc.NetPrincipalLocal.Amount,
                NetTradeValueLocal = alloc.NetTradeValueLocal.Amount,
                NetTradeValueBase = alloc.NetTradeValueBase.Amount,
                PortfolioId = alloc.PortfolioId,
                TradeAllocationId = alloc.Id,




            };


        }
        public static IEnumerable<Entities.Position> Map(this IEnumerable<Position> positions)
        {
            return positions.Select(x => x.Map());
        }
        public static Entities.Position Map(this Position pos)
        {
            return new Entities.Position()
            {
                BaseCurrency = pos.BaseCurrency,
                NominalQuantity = pos.NominalQuantity,
                PositionDate = pos.PositionDate.ToDateTime(TimeOnly.MinValue),
                FirstTradeDate = pos.FirstTradeDate.ToDateTime(TimeOnly.MinValue),
                GrossEntryPriceBase = pos.GrossEntryPriceBase.Amount,
                GrossEntryPriceLocal = pos.GrossEntryPriceLocal.Amount,
                GrossTradeValueBase = pos.GrossTradeValueBase.Amount,
                GrossTradeValueLocal = pos.GrossTradeValueLocal.Amount,
                InstrumentId = pos.InstrumentId,
                IsSwap = pos.IsSwap,
                LastTradeDate = pos.LastTradeDate.ToDateTime(TimeOnly.MinValue),
                LocalCurrency = pos.LocalCurrency,
                GrossNotionalValueBase = pos.GrossNotionalValueBase.Amount,
                GrossNotionalValueLocal = pos.GrossNotionalValueLocal.Amount,
                NetNotionalValueBase = pos.NetNotionalValueBase.Amount,
                NetNotionalValueLocal = pos.NetNotionalValueLocal.Amount,

                NetEntryPriceBase = pos.NetEntryPriceBase.Amount,
                NetEntryPriceLocal = pos.NetEntryPriceLocal.Amount,
                NetTradeValueBase = pos.NetTradeValueBase.Amount,
                NetTradeValueLocal = pos.NetTradeValueLocal.Amount,
                PortfolioId = pos.PortfolioId,
                Quantity = pos.Quantity,
                TotalCommissionBase = pos.TotalCommissionBase.Amount,
                TotalCommissionLocal = pos.TotalCommissionLocal.Amount, 
            };


        }
        public static IEnumerable<Position> Map(this IEnumerable<Entities.Position> entities)
        {
            return entities.Select(x => x.Map());
        }
        public static Position Map(this Entities.Position entity)
        {
            return new Position(
            entity.PortfolioId,
         new InvestedInstrument( entity.InstrumentId, entity.IsSwap),
         DateOnly.FromDateTime(entity.PositionDate),
         entity.Quantity,
         entity.NominalQuantity,
         entity.LocalCurrency,
         entity.BaseCurrency,
         entity.GrossEntryPriceLocal,
         entity.GrossEntryPriceBase,
         entity.NetEntryPriceLocal,
         entity.NetEntryPriceBase,
         entity.GrossTradeValueLocal,
         entity.GrossTradeValueBase,
         entity.NetTradeValueLocal,
         entity.NetTradeValueBase,
         entity.GrossNotionalValueLocal,
         entity.GrossNotionalValueBase,
         entity.NetNotionalValueLocal,
         entity.NetNotionalValueBase,
         entity.TotalCommissionLocal,
         entity.TotalCommissionBase,
         DateOnly.FromDateTime(entity.FirstTradeDate),
         DateOnly.FromDateTime(entity.LastTradeDate)
                );


        }


    }
}
