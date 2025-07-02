using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Entities = Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
using Quantaventis.Trading.Shared.Infrastructure.Database;


using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Valuation.Domain.Model;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Mappers
{
    internal static class Extensions
    {
        public static Instrument Map(this Entities.Instrument instrument)
        {
            switch (instrument.InstrumentType)
            {

                case "EQU": return new Equity(instrument.InstrumentId);

                case "CFD": return new CFD(instrument.InstrumentId);
                case "FUT": return new FutureContract(instrument.InstrumentId, new Money(instrument.FutureContract.PointValue, instrument.Currency));
                case "FXFWD": return new FxForward(instrument.InstrumentId);
                default: throw new InvalidOperationException($"Instrument {instrument.InstrumentId} couldn't by mapped. The Instrument type {instrument.InstrumentType} is not recognized");
            }

        }

        public static IEnumerable<Instrument> Map(this IEnumerable<Entities.Instrument> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }
        public static InstrumentPricing Map(this Entities.InstrumentPricing entity)
        {
            return new InstrumentPricing(
                entity.InstrumentId,
                new Money(entity.Price, entity.Currency),
                entity.Date);
        }
        public static IEnumerable<FxRate> Map(this IEnumerable<Entities.FxRate> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }
        public static FxRate Map(this Entities.FxRate entity)
        {
            return new FxRate(
                entity.Value,
                entity.BaseCurrency,
                entity.QuoteCurrency);
        }
        public static TargetWeight Map(this Entities.TargetWeight entity)
        {
            return new TargetWeight(
                entity.Instrument.Map(),
                entity.Weight);
        }

        public static IEnumerable<TargetWeight> Map(this IEnumerable<Entities.TargetWeight> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }
        public static Entities.TargetWeightValuation Map(this TargetWeightValuation domain)
        {
            return new Entities.TargetWeightValuation()
            {
                InstrumentId = domain.Instrument.Id,
                TargetNetExposure = domain.TargetNetExposure.Amount,
                TargetGrossExposure = domain.TargetGrossExposure.Amount,
                Weight = domain.Weight,
                Price = domain.Price.Amount,
                PriceCurrency = domain.Price.Currency,
                PricedOn = domain.PricedOn,
                InstrumentValue = domain.InstrumentValue.Amount,
                TargetQuantity = domain.TargetQuantity
            };

        }
        public static Entities.TargetAllocationValuation Map(this TargetAllocationValuation domain)
        {
           var entity = new Entities.TargetAllocationValuation()
            {
                TargetAllocationId = domain.TargetAllocation.Id,
                PortfolioValue = domain.PortfolioValue.Amount,
                TargetNetExposure = domain.TargetNetExposure.Amount,
                TargetGrossExposure = domain.TargetGrossExposure.Amount,
                TotalWeight = domain.TotalWeight,
                ValuatedOn = domain.ValuatedOn,
                ValuationCurrency = domain.ValuationCurrency,

            };
            domain.TargetWeightValuations.ToList().ForEach(x => entity.TargetWeightValuations.Add(x.Map()));
            return entity;
        }

        public static IEnumerable<Entities.TargetWeightValuation> Map(this IEnumerable<TargetWeightValuation> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }
        internal static IEnumerable<TargetAllocation> Map(this IEnumerable<Entities.TargetAllocation> positionValuations)
            => positionValuations.Select(x => x.Map());
        public static TargetAllocation Map(this Entities.TargetAllocation entity)
        {
            return new TargetAllocation(
                entity.TargetAllocationId,
                entity.PortfolioId,
                entity.GeneratedOn,
               entity.TargetWeights.Map());
        }
        public static Portfolio Map(this Entities.Portfolio entity)
        {
            return new Portfolio(
                entity.PortfolioId,
                new Currency(entity.Currency),
                entity.Positions.Map(entity.Currency),
                new Money(entity.TotalValue, entity.Currency));
        }
        public static IEnumerable<Portfolio> Map(this IEnumerable<Entities.Portfolio> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }
        public static IEnumerable<Position> Map(this IEnumerable<Entities.Position> entities, Currency portfolioCurrency)
        {
            return entities.Select(x => x.Map(portfolioCurrency)).ToList();

        }
        public static Position Map(this Entities.Position entity, Currency portfolioCurrency)
        {
            var currency = entity.Instrument.Currency;
            return new Position(
                entity.Instrument.Map(),
                new Quantity(entity.Quantity),
                new AverageEntryCost(
                    new Money(entity.AvgEntryPriceLocal, currency), 
                    new FxRate(entity.AvgEntryPriceLocal, currency, portfolioCurrency))
                );
        }

        public static Entities.PortfolioValuation Map(this PortfolioValuation domain)
        {
            var entity = new Entities.PortfolioValuation()
            {
                PortfolioId = domain.PortfolioId,
                Currency = domain.Currency,
                TotalValue = domain.TotalValue.Amount,
                NetExposure = domain.NetExposure.Amount,
                GrossExposure = domain.GrossExposure.Amount,
                PnL = domain.PnL.Amount,
                Roi = domain.ROI.Amount,
                ValuationDate = domain.ValuationDate

            };
            domain.PositionValuations.ToList().ForEach(x => entity.PositionValuations.Add(x.Map()));
            return entity;
        }
        public static Entities.PositionValuation Map(this PositionValuation domain)
        {
            return new Entities.PositionValuation()
            {
                InstrumentId = domain.InstrumentId,
                InstrumentPrice = domain.InstrumentPricing.Price.Amount,
                InstrumentPriceCurrency = domain.InstrumentPricing.Price.Currency,
                InstrumentPriceDate = domain.PriceDate,
                InstrumentValue = domain.InstrumentValue.Amount,
                FxRate = domain.FxRate.Value,
                Quantity = domain.Quantity,
                ValuationCurrency = domain.ValuationCurrency,
                GrossExposure = domain.GrossExposure.Amount,
                NetExposure = domain.NetExposure.Amount,
                PnL = domain.Pnl.Amount,
                Roi = domain.ROI.Amount,
                Weight = domain.Weight

            };
        }
        public static IEnumerable<Entities.PositionValuation> Map(this IEnumerable<PositionValuation> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }

        public static IEnumerable<InstrumentPricing> Map(this IEnumerable<Entities.InstrumentPricing> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }
    }


}
