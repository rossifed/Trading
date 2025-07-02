
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Entities=Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Rebalancing.Api.Dto;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Mappers;
using System.Linq;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Mappers
{
    internal static class Extensions
    {
        internal static Entities.Instrument Map(this InstrumentDto dto)
        => new Entities.Instrument()
        {
            InstrumentId = dto.Id,
            Symbol = dto.Symbol,
            Currency= dto.Currency,
            InstrumentType = dto.InstrumentType
        };

        internal static TargetPosition Map(this TargetWeightValuationDto dto)
        => new TargetPosition(new Instrument(dto.InstrumentId), dto.TargetQuantity, dto.Weight);
        internal static Entities.Portfolio Map(this PortfolioDto dto)
         => new Entities.Portfolio()
         {
             PortfolioId = dto.Id,
             Mnemonic = dto.Mnemonic,
             Name = dto.Name,
             Currency = dto.Currency
         };
        internal static IEnumerable<Entities.Portfolio> Map(this IEnumerable<PortfolioDto> dtos)
        => dtos.Select(x => x.Map());


        internal static IEnumerable<TargetPosition> Map(this IEnumerable<TargetWeightValuationDto> dtos)
            => dtos.Select(x => x.Map());
        internal static TargetAllocationValuation Map(this TargetAllocationValuationDto dto)
        {
            return new TargetAllocationValuation(
                    dto.TargetAllocationValuationId,
                    dto.TargetAllocationId,
                    dto.PortfolioId,
                    new Money(dto.PortfolioValue, dto.ValuationCurrency),
                    dto.TargetNetExposure,
                    dto.TargetGrossExposure,
                    dto.ValuatedOn,
                    dto.TargetWeightValuations.Map());                           
        }


        internal static InvestedPosition Map(this PositionValuationDto dto)
        => new InvestedPosition(new Instrument(dto.InstrumentId), dto.Quantity, dto.Weight);


        internal static IEnumerable<InvestedPosition> Map(this IEnumerable<PositionValuationDto> dtos)
             => dtos.Select(x => x.Map());
        internal static PortfolioValuation Map(this PortfolioValuationDto dto)
        {
            return new PortfolioValuation(
                    dto.PortfolioValuationId,
                    dto.PortfolioId,
                    new Money(dto.PortfolioValue, dto.ValuationCurrency),
                    dto.NetExposure,
                    dto.GrossExposure,
                    dto.ValuationDate,
                    dto.PositionValuations.Map());
        }
        internal static PositionDriftDto Map(this PositionDrift domain)
        {
            return new PositionDriftDto()
            {
                InstrumentId = domain.Instrument.Id,
                QuantityDrift = domain.QuantityDrift.Amount,
            };
        }
        internal static RebalancingOrderDto Map(this Order domain)
        {
            return new RebalancingOrderDto()
            {
                RebalancingSessionId =domain.RebalancingSessionId,
                PortfolioId = domain.PortfolioId,
                InstrumentId = domain.Instrument.Id,
                Quantity = domain.Quantity,
                CurrentPositionQuantity= domain.CurrentPositionQuantity,
                TradeDate= domain.TradeDate,
                TargetPositionQuantity = domain.TargetPositionQuantity
            };
        }
        internal static IEnumerable<RebalancingOrderDto> Map(this IEnumerable<Order> dtos)
          => dtos.Select(x => x.Map());
        internal static IEnumerable<PositionDriftDto> Map(this IEnumerable<PositionDrift> dtos)
            => dtos.Select(x => x.Map());

        internal static IEnumerable<PortfolioDriftDto> Map(this IEnumerable<PortfolioDrift> dtos)
                 => dtos.Select(x => x.Map());

        internal static PortfolioDriftDto Map(this PortfolioDrift domain)
        {
            return new PortfolioDriftDto()
            {
                PortfolioDriftId = domain.Id,
                PortfolioId = domain.PortfolioId,
                TargetAllocationId= domain.TargetAllocationId,
                TargetAllocationValuationId= domain.TargetAllocationValuationId,
                PortfolioValuationId= domain.PortfolioValuationId,
                PositionDrifts = domain.PositionDrifts.Map()
            };
        }
        internal static RebalancingDto Map(this PortfolioRebalancing domain)
        {
            return new RebalancingDto()
            {
                RebalancingId= domain.RebalancingId,
                PortfolioId  = domain.PortfolioId,
                TargetAllocationId = domain.TargetAllocationId,
                PortfolioDriftId = domain.PortfolioDriftId,
                TargetAllocationValuationId = domain.TaretAllocationValuationId,
                PortfolioValuationId= domain.PortfolioValuationId,
                PositionDrifts = domain.PositionDrifts.Map(),
                StartedOn = domain.StartedOn

            };

        }

        internal static RebalancingSessionDto Map(this RebalancingSession domain)
        {
            return new RebalancingSessionDto()
            {
                RebalancingSessionId = domain.Id,
                PortfolioDrifts = domain.PortfolioDrifts.Map(),
                TradeDate = domain.TradeDate,
                Orders = domain.GetOrders().Map(),
                StartedOn = domain.StartedOn

            };
        }
    }
}
