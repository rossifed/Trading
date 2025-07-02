using Quantaventis.Trading.Modules.Portfolios.Api.Dto;
using Entities = Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Portfolios.Domain.Model;
using Quantaventis.Trading.Shared.Infrastructure;

namespace Quantaventis.Trading.Modules.Portfolios.Api.Mappers
{
    internal static class Extensions
    {

        internal static Entities.Instrument Map(this InstrumentDto dto)
    => new Entities.Instrument()
    {
        InstrumentId = dto.Id,
        Symbol = dto.Symbol,
        Name= dto.Name,
        Currency = dto.Currency,
        MarketSector= dto.MarketSector,
        InstrumentType = dto.InstrumentType
    };


        internal static IEnumerable<Entities.BookedTradeAllocation> Map(this IEnumerable<BookedTradeDto> tradeDtos)
            => tradeDtos.SelectMany(x => x.Map()).ToList();
        internal static IEnumerable<Entities.BookedTradeAllocation> Map(this BookedTradeDto tradeDto)
        {
            var allocationDtos = tradeDto.TradeAllocations;
           return allocationDtos.Select(x => new Entities.BookedTradeAllocation()
            {
                TradeId = x.TradeId,
                Commission = x.CommissionAmountLocal,
                Fees = x.MiscFeesAmountLocal,
                GrossAmount  = x.GrossPrincipalLocal,
                InstrumentId = tradeDto.InstrumentId,
                LastTradeDate = tradeDto.TradeDate,
                IsSwap = tradeDto.IsSwap,
                NetAmount = x.NetPrincipalLocal,
                PortfolioId = x.PortfolioId,
                Quantity = x.Quantity,
                TradeAllocationId = x.TradeAllocationId,
                TradeCurrency = x.LocalCurrency,
                TradePrice = x.GrossAvgPriceLocal,
                

            }).ToList();
                
        
        }


        internal static IEnumerable<PortfolioDto> Map(this IEnumerable<Entities.Portfolio> portfolios)
        {

            return portfolios.Select(x => x.Map());
        }
        internal static PortfolioDto Map(this Entities.Portfolio portfolio)
        {

            return new PortfolioDto()
            {
                Id = portfolio.PortfolioId,
                Name = portfolio.Name,
                Mnemonic = portfolio.Mnemonic,
                Currency = portfolio.Currency
            };
        }

        //internal static IEnumerable<PositionDto> Map(this IEnumerable<Entities.VwPosition> portfolios)
        //{

        //    return portfolios.Select(x => x.Map());
        //}
        //internal static PositionDto Map(this Entities.VwPosition entity)
        //{

        //    return new PositionDto()
        //    {
        //        PortfolioId = entity.PortfolioId,
        //        AvgTradePriceLocal = entity.AvgTradePriceLocal.Value,
        //        GrossTotalCostLocal = entity.GrossTotalCostLocal.Value,
        //        InstrumentId = entity.InstrumentId,
        //        NetTotalCostLocal = entity.NetTotalCostLocal.Value,
        //        PositionDate = DateOnly.FromDateTime(entity.PositionDate.Value),      
        //    };
        //}


        internal static IEnumerable<Entities.TradeAllocation> Map(this IEnumerable<TradeAllocationDto> tradeAllocationDtos, TradeDto tradeDto)
        {

            return tradeAllocationDtos.Select(x => x.Map(tradeDto));
        }
        internal static Entities.TradeAllocation Map(this TradeAllocationDto dto, TradeDto tradeDto)
        {
            return new Entities.TradeAllocation()
            {
                Commission = dto.Commission,
                Fees = dto.Fees,
                GrossAmount = dto.GrossAmount,
                NetAmount = dto.NetAmount,
                LastTradeDate = tradeDto.TradeDate,
                InstrumentId = tradeDto.InstrumentId,
                PortfolioId = dto.PortfolioId,
                Quantity = dto.Quantity,
                TradeCurrency = tradeDto.TradeCurrency,
                TradeAllocationId = dto.TradeAllocationId,
                TradePrice = dto.Price
            };     
        }  
    }
}
