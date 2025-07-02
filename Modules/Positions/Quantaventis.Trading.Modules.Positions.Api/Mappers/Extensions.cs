
using Microsoft.Extensions.DependencyInjection;

//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Positions.Infrastructure;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Positions.Domain.Model;
using Quantaventis.Trading.Modules.Positions.Api.Events;
using Quantaventis.Trading.Modules.Positions.Api.Dto;

namespace Quantaventis.Trading.Modules.Positions.Api.Mappers
{
    internal static class Extensions
    {
        public static IEnumerable<TradeAllocation> MapTradeAllocations(this BookedTradeDto tradeDto)
        {
            return tradeDto.TradeAllocations.Select(x => tradeDto.Map(x));


        }
 
        public static TradeAllocation Map(this BookedTradeDto tradeDto, BookedTradeAllocationDto allocDto)
        {
            return new TradeAllocation(allocDto.TradeAllocationId,
              tradeDto.TradeId,
            allocDto.PortfolioId,
            allocDto.Quantity,
            allocDto.NominalQuantity,
            new InvestedInstrument(tradeDto.InstrumentId,tradeDto.IsSwap),
            DateOnly.FromDateTime(tradeDto.TradeDate),
            allocDto.GrossAvgPriceLocal,
            allocDto.GrossAvgPriceBase,
            allocDto.NetAvgPriceLocal,
            allocDto.NetAvgPriceBase,
            allocDto.GrossTradeValueLocal,
            allocDto.GrossTradeValueBase,
            allocDto.NetTradeValueLocal,
            allocDto.NetTradeValueBase,
            allocDto.GrossPrincipalLocal,
            allocDto.GrossPrincipalBase,
            allocDto.NetPrincipalLocal,
            allocDto.NetPrincipalBase,
            allocDto.CommissionAmountLocal,
            allocDto.CommissionAmountBase,
            allocDto.LocalCurrency,
            allocDto.BaseCurrency,
            allocDto.LocalToBaseFxRate);


        }
        public static IEnumerable<PositionDto> Map(this IEnumerable<Position> positions)
        {
            return positions.Select(x => x.Map());
        }
            public static PositionDto Map(this Position pos)
        {
            return new PositionDto()
            {
                BaseCurrency = pos.BaseCurrency,
                PositionDate = pos.PositionDate,
                FirstTradeDate = pos.FirstTradeDate,
                GrossEntryPriceBase = pos.GrossEntryPriceBase.Amount,
                GrossEntryPriceLocal = pos.GrossEntryPriceLocal.Amount,
                GrossTradeValueBase = pos.GrossTradeValueBase.Amount,
                GrossTradeValueLocal = pos.GrossTradeValueLocal.Amount,
                GrossNotionalValueBase = pos.GrossNotionalValueBase.Amount,
                GrossNotionalValueLocal = pos.GrossNotionalValueLocal.Amount,
                InstrumentId = pos.InstrumentId,
                IsSwap = pos.IsSwap,
                LastTradeDate = pos.LastTradeDate,
                LocalCurrency = pos.LocalCurrency,
                NominalQuantity = pos.NominalQuantity,
              
                NetEntryPriceBase = pos.NetEntryPriceBase.Amount,
                NetEntryPriceLocal = pos.NetEntryPriceLocal.Amount,
                NetTradeValueBase = pos.NetTradeValueBase.Amount,
                NetTradeValueLocal = pos.NetTradeValueLocal.Amount,
                NetNotionalValueBase = pos.NetNotionalValueBase.Amount,
                NetNotionalValueLocal = pos.NetNotionalValueLocal.Amount,
                PortfolioId = pos.PortfolioId,
                Quantity = pos.Quantity,
                TotalCommissionBase = pos.TotalCommissionBase.Amount,
                TotalCommissionLocal = pos.TotalCommissionLocal.Amount,
            };
        }
    }
}
