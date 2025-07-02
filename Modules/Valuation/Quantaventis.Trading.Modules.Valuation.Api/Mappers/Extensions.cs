using Quantaventis.Trading.Modules.Valuation.Api.Dto;
using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using Entities = Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Valuation.Api.Mappers
{
    internal static class Extensions
    {

        internal static PortfolioValuationDto Map(this PortfolioValuation ptfVal, int portfolioValuationId)
        {
            return new PortfolioValuationDto()
            {
                PortfolioValuationId = portfolioValuationId,
                PortfolioId = ptfVal.PortfolioId,
                NetExposure = ptfVal.NetExposure.Amount,
                GrossExposure = ptfVal.GrossExposure.Amount,
                PortfolioValue = ptfVal.TotalValue.Amount,
                ROI = ptfVal.ROI.Amount,
                PnL = ptfVal.PnL.Amount,
                ValuationCurrency = ptfVal.Currency,
                ValuationDate = ptfVal.ValuationDate,
                PositionValuations = ptfVal.PositionValuations.Map()

            };
        }
        internal static IEnumerable<PositionValuationDto> Map(this IEnumerable<PositionValuation> positionValuations)
         => positionValuations.Select(x => x.Map());
        internal static PositionValuationDto Map(this PositionValuation positionValuation)
        {
            return new PositionValuationDto()
            {
                PriceInLocalCcy = positionValuation.Price.Amount,
                InstrumentId = positionValuation.Instrument.Id,
                InstrumentPrice = positionValuation.Price.Amount,
                InstrumentCurrency = positionValuation.Price.Currency,
                PriceDate = positionValuation.PriceDate,
                InstrumentValue = positionValuation.InstrumentValue.Amount,
                Quantity = positionValuation.Quantity,
                FxRate = positionValuation.FxRate.Value,
                GrossExposure = positionValuation.GrossExposure.Amount,
                NetExposure = positionValuation.NetExposure.Amount,
                UnrealizedPnL = positionValuation.Pnl.Amount,
                ROI = positionValuation.ROI.Amount,
                Weight = positionValuation.Weight,
                ValuationCurrency = positionValuation.ValuationCurrency
            };
        }

        internal static IEnumerable<TargetWeightValuationDto> Map(this IEnumerable<TargetWeightValuation> dtos)
            => dtos.Select(x => x.Map());
        internal static TargetWeightValuationDto Map(this TargetWeightValuation domain)
        {
            return new TargetWeightValuationDto()
            {
                TargetQuantity = domain.TargetQuantity,
                InstrumentId = domain.Instrument.Id,
                InstrumentValue = domain.InstrumentValue.Amount,
                Price = domain.Price.Amount,
                PricedOn = domain.PricedOn,
                PriceCurrency = domain.Price.Currency.Code,
                ValuationCurrency = domain.InstrumentValue.Currency.Code,
                TargetNetExposure = domain.TargetNetExposure.Amount,
                TargetGrossExposure = domain.TargetGrossExposure.Amount,
                Weight = domain.Weight,

            };
        }
        internal static TargetAllocationValuationDto Map(this TargetAllocationValuation domain, int targetAllocationValuationId)
        {
            return new TargetAllocationValuationDto()
            {
                TargetAllocationValuationId = targetAllocationValuationId,
                PortfolioId = domain.PortfolioId,
                TargetAllocationId = domain.TargetAllocation.Id,
                PortfolioValue = domain.PortfolioValue.Amount,
                TargetGrossExposure = domain.TargetGrossExposure.Amount,
                TargetNetExposure = domain.TargetNetExposure.Amount,
                TotalWeight = domain.TotalWeight,
                ValuatedOn = domain.ValuatedOn,
                ValuationCurrency = domain.ValuationCurrency,
                TargetWeightValuations = domain.TargetWeightValuations.Map()
            };
        }

        internal static TargetAllocationDto Map(this TargetAllocation domain)
        {
            return new TargetAllocationDto()
            {
                TargetAllocationId = domain.Id,
                PortfolioId = domain.PortfolioId,
                GeneratedOn = domain.GeneratedOn,

            };
        }
        internal static IEnumerable<Entities.Portfolio> Map(this IEnumerable<PortfolioDto> dtos)
            => dtos.Select(x => x.Map());
        internal static Entities.Portfolio Map(this PortfolioDto dto)
        {
            return new Entities.Portfolio()
            {
                PortfolioId = dto.Id,
                Mnemonic = dto.Mnemonic,
                Currency = dto.Currency,
                Name = dto.Name,
                TotalValue = 0

            };
        }

        internal static Entities.TargetAllocation Map(this TargetAllocationDto dto)
        {
            var entity = new Entities.TargetAllocation()
            {
                PortfolioId = dto.PortfolioId,
                TargetAllocationId = dto.TargetAllocationId,
                GeneratedOn = dto.GeneratedOn

            };

            dto.TargetWeights.ToList().ForEach(x => entity.TargetWeights.Add(x.Map()));
            return entity;
        }

        internal static Entities.TargetWeight Map(this TargetWeightDto dto)
        {
            return new Entities.TargetWeight()
            {
                InstrumentId = dto.InstrumentId,
                Weight = dto.Weight
            };
        }
        internal static IEnumerable<Entities.TargetWeight> Map(this IEnumerable<TargetWeightDto> dtos)
            => dtos.Select(x => x.Map());

    }
}
