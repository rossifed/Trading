using Microsoft.Extensions.DependencyInjection;

using Entities = Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;
using Quantaventis.Trading.Shared.Infrastructure.Database;


using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;


namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Mappers
{
    internal static class Extensions
    {

        internal static IEnumerable<PositionDrift> Map(this IEnumerable<Entities.PositionDrift> entities)
            => entities.Select(x => x.Map());
        internal static PositionDrift Map(this Entities.PositionDrift entity)
         => new PositionDrift(
               new InvestedPosition(
                       new Instrument(entity.InstrumentId),
                       entity.CurrentQuantity,
                       entity.CurrentWeight),
                   new TargetPosition(
                       new Instrument(entity.InstrumentId),
                       entity.TargetQuantity,
                       entity.TargetWeight));

        internal static InvestedPosition Map(this Entities.PositionValuation entity)
          => new InvestedPosition(
                 new Instrument(entity.InstrumentId),
                 entity.Quantity,
                 entity.Weight);

        internal static IEnumerable<InvestedPosition> Map(this IEnumerable<Entities.PositionValuation> entities)
            => entities.Select(x => x.Map());
        internal static IEnumerable<TargetPosition> Map(this IEnumerable<Entities.TargetWeightValuation> entities)
            => entities.Select(x => x.Map());

        internal static TargetPosition Map(this Entities.TargetWeightValuation entity)
       => new TargetPosition(
                       new Instrument(entity.InstrumentId),
                       entity.TargetQuantity,
                       entity.Weight);

        internal static PortfolioValuation Map(this Entities.PortfolioValuation entity)
        {
            return new PortfolioValuation(entity.PortfolioValuationId,
                entity.PortfolioId,
                new Money(entity.TotalValue, entity.Currency),
                entity.NetExposure,
                entity.GrossExposure,
                entity.ValuationDate,
                entity.PositionValuations.Map()
                );
        }
        internal static TargetAllocationValuation Map(this Entities.TargetAllocationValuation entity)
        {
            return new TargetAllocationValuation(
                entity.TargetAllocationValuationId,
                entity.TargetAllocationId,
                entity.PortfolioId,
                new Money(entity.PortfolioValue, entity.ValuationCurrency),
                entity.TargetNetExposure,
                entity.TargetGrossExposure,
                entity.ValuatedOn,
                entity.TargetWeightValuations.Map()
                );
        }
        internal static IEnumerable<Entities.PortfolioDrift> Map(this IEnumerable<PortfolioDrift> entities)
         => entities.Select(x => x.Map());

        internal static IEnumerable<PortfolioDrift> Map(this IEnumerable<Entities.PortfolioDrift> entities)
            => entities.Select(x => x.Map());
        internal static PortfolioDrift Map(this Entities.PortfolioDrift entity)
        {
            return new PortfolioDrift(
                entity.PortfolioDriftId,
                entity.PortfolioId,
                entity.PortfolioValuationId,
                entity.TargetAllocationId,
                entity.TargetAllocationValuationId,
                new WeightDrift(entity.PortfolioNetExposure, entity.TargetNetExposure),
                new WeightDrift(entity.PortfolioGrossExposure, entity.TargetGrossExposure),
                entity.PositionDrifts.Map()
                );
        }
        internal static IEnumerable<Entities.PositionDrift> Map(this IEnumerable<PositionDrift> entities)
                 => entities.Select(x => x.Map());
        internal static Entities.PositionDrift Map(this PositionDrift domain)
        {
            return new Entities.PositionDrift()
            {
                InstrumentId = domain.Instrument.Id,
                CurrentWeight = domain.WeightDrift.CurrentWeight,
                TargetWeight = domain.WeightDrift.TargetWeight,
                WeightDrift = domain.WeightDrift.Amount,
                CurrentQuantity = domain.QuantityDrift.CurrentQuantity,
                TargetQuantity = domain.QuantityDrift.TargetQuantity,
                QuantityDrift = domain.QuantityDrift.Amount
            };
        }
        internal static Entities.PositionValuation Map(this InvestedPosition domain)
        {
            return new Entities.PositionValuation()
            {
                InstrumentId= domain.Instrument.Id,
                Quantity = domain.Quantity,
                Weight = domain.Weight
            };
        }
        internal static Entities.PortfolioValuation Map(this PortfolioValuation domain)
        {
            var entity = new Entities.PortfolioValuation()
            {
                PortfolioId  = domain.PortfolioId,
                PortfolioValuationId = domain.Id,
                TotalValue = domain.PortfolioValue.Amount,
                Currency = domain.PortfolioValue.Currency,
                GrossExposure= domain.GrossExposure,
                NetExposure = domain.NetExposure,
                ValuationDate = domain.ValuatedOn
            };

            domain.Positions.ToList().ForEach(x => entity.PositionValuations.Add(x.Map()));
            return entity;
        }

        internal static Entities.TargetAllocationValuation Map(this TargetAllocationValuation domain)
        {
            var entity = new Entities.TargetAllocationValuation()
            {
                PortfolioId = domain.PortfolioId,
                TargetAllocationValuationId = domain.Id,
                TargetAllocationId = domain.TargetAllocationId,
                PortfolioValue = domain.PortfolioValue.Amount,
                TargetGrossExposure = domain.GrossExposure,
                TargetNetExposure = domain.NetExposure,
                ValuatedOn = domain.ValuatedOn,
                ValuationCurrency = domain.PortfolioValue.Currency
            };

            domain.TargetPositions.ToList().ForEach(x => entity.TargetWeightValuations.Add(x.Map()));
            return entity;
        }

        internal static Entities.TargetWeightValuation Map(this TargetPosition domain)
        {
            return new Entities.TargetWeightValuation()
            {
                InstrumentId = domain.Instrument.Id,
                TargetQuantity = domain.Quantity,
                Weight = domain.Weight
            };
        }
        internal static Entities.PortfolioDrift Map(this PortfolioDrift domain)
        {
            var entity = new Entities.PortfolioDrift()
            {
                PortfolioDriftId = domain.Id,
                PortfolioValuationId = domain.PortfolioValuationId,
                TargetAllocationValuationId = domain.TargetAllocationValuationId,               
                GrossExposureDrift = domain.GrossExposureDrift.Amount,          
                NetExposureDrift = domain.NetExposureDrift.Amount,
                PortfolioGrossExposure = domain.PortfolioGrossExposure,
                PortfolioNetExposure = domain.PortfolioNetExposure,
                TargetGrossExposure = domain.TargetGrossExposure,
                TargetNetExposure = domain.TargetNetExposure,
                PortfolioId = domain.PortfolioId,
                TargetAllocationId = domain.TargetAllocationId
            };

            domain.PositionDrifts.ToList().ForEach(x => entity.PositionDrifts.Add(x.Map()));
            return entity;
        }


        internal static Entities.RebalancingSession Map(this RebalancingSession domain)
        {
            var entity = new Entities.RebalancingSession()
            {
                RebalancingSessionId = domain.Id,
                Status = domain.RebalancingStatus.Label,
                StatusReason = domain.StatusReason.Label,
                TradeDate = domain.TradeDate.ToDateTime(TimeOnly.MinValue),
                StartedOn = domain.StartedOn,
                EndedOn = domain.EndedOn,

            };
            foreach (var driftDomain in domain.PortfolioDrifts)
            {
                var driftEntity = new Entities.PortfolioDrift { PortfolioDriftId = driftDomain.Id };

                entity.PortfolioDrifts.Add(driftEntity);  // Add it to the RebalancingSession's PortfolioDrifts collection
            }

            return entity;
        }
        internal static RebalancingSession Map(this Entities.RebalancingSession entity)
        {
            return new RebalancingSession(
                 entity.RebalancingSessionId,          
                 entity.PortfolioDrifts.Map(),
                 DateOnly.FromDateTime(entity.TradeDate),
                 entity.StartedOn,
                 RebalancingStatus.StatusReason.FromLabel(entity.StatusReason),
                 entity.EndedOn//TODO: apply status reason resolution
                 );
        }

      

       
     
    }
}
