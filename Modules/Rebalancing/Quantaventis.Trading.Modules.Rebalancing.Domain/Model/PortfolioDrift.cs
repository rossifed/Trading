namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class PortfolioDrift
    {
        internal int Id { get; }
        internal PortfolioId PortfolioId { get; }
        internal int TargetAllocationValuationId { get; }
        internal int PortfolioValuationId { get; }
        internal int TargetAllocationId { get; }

        internal WeightDrift NetExposureDrift { get; }
        internal WeightDrift GrossExposureDrift { get; }
        internal Weight PortfolioNetExposure => NetExposureDrift.CurrentWeight;
        internal Weight TargetNetExposure => NetExposureDrift.TargetWeight;
        internal Weight PortfolioGrossExposure => GrossExposureDrift.CurrentWeight;
        internal Weight TargetGrossExposure => GrossExposureDrift.TargetWeight;
        internal IEnumerable<PositionDrift> PositionDrifts { get; }
        internal IEnumerable<TargetPosition> TargetPositions => PositionDrifts.Select(x => x.TargetPosition);
        internal IEnumerable<InvestedPosition> CurrentPositions => PositionDrifts.Select(x => x.InvestedPosition);



        internal PortfolioDrift(int id, PortfolioValuation portfolioValuation,
            TargetAllocationValuation targetAllocationValuation) : this(
                id,
                portfolioValuation.PortfolioId,
                portfolioValuation.Id,
                targetAllocationValuation.TargetAllocationId,
                targetAllocationValuation.Id,
                new WeightDrift(portfolioValuation.NetExposure, targetAllocationValuation.NetExposure),
                new WeightDrift(portfolioValuation.GrossExposure, targetAllocationValuation.GrossExposure),
                ComputePositionDrifts(portfolioValuation.Positions, targetAllocationValuation.TargetPositions)
                )
        { }



        internal PortfolioDrift(int id,
            byte portfolioId,
            int portfolioValuationId,
            int targetAllocationId,
            int targetAllocationValuationId,
            WeightDrift netExposureDrift,
            WeightDrift grossExposureDrift, IEnumerable<PositionDrift> positionDrifts)
        {
            this.Id = id;
            PortfolioId = portfolioId;
            PortfolioValuationId = portfolioValuationId;
            TargetAllocationId = targetAllocationId;
            TargetAllocationValuationId = targetAllocationValuationId;
            NetExposureDrift = netExposureDrift;
            GrossExposureDrift = grossExposureDrift;
            PositionDrifts = positionDrifts;
        }



        internal static PortfolioDrift New(PortfolioValuation portfolioValuation, TargetAllocationValuation targetAllocation)
        {
            return new PortfolioDrift(0, portfolioValuation,
                targetAllocation);
        }

        internal PortfolioDrift Update(TargetAllocationValuation targetAllocationValuation)
        {
            return new PortfolioDrift(
                Id,
                PortfolioId,
                PortfolioValuationId,
                targetAllocationValuation.TargetAllocationId,
                targetAllocationValuation.Id,
                NetExposureDrift.UpdateTargetWeight(targetAllocationValuation.NetExposure),
                GrossExposureDrift.UpdateCurrentWeight(targetAllocationValuation.GrossExposure),
                ComputePositionDrifts(CurrentPositions, targetAllocationValuation.TargetPositions));
        }

        internal PortfolioDrift Update(PortfolioValuation portfolioValuation)
        {
            return new PortfolioDrift(Id,
                portfolioValuation.PortfolioId,
                portfolioValuation.Id,
                TargetAllocationId,
                TargetAllocationValuationId,
                NetExposureDrift.UpdateCurrentWeight(portfolioValuation.NetExposure),
                GrossExposureDrift.UpdateCurrentWeight(portfolioValuation.GrossExposure),
                ComputePositionDrifts(portfolioValuation.Positions, TargetPositions));
        }


        private static IEnumerable<PositionDrift> ComputePositionDrifts(IEnumerable<InvestedPosition> currentPositions, IEnumerable<TargetPosition> targetPositions)
              => ComputePositionDrifts(currentPositions.ToDictionary(x => x.Instrument), targetPositions)
                  .Union(ComputePositionDrifts(targetPositions.ToDictionary(x => x.Instrument), currentPositions));

        private static IEnumerable<PositionDrift> ComputePositionDrifts(IDictionary<Instrument, InvestedPosition> currentPositions, IEnumerable<TargetPosition> targetPositions)
                => targetPositions
                    .Select(x => currentPositions.ContainsKey(x.Instrument) ?
                    new PositionDrift(currentPositions[x.Instrument], x)
                    :
                    PositionDrift.FromFlatInvestedPosition(x))
                    .ToList();

        private static IEnumerable<PositionDrift> ComputePositionDrifts(IDictionary<Instrument, TargetPosition> targetPositions, IEnumerable<InvestedPosition> investedPositions)
             => investedPositions
                 .Select(x => targetPositions.ContainsKey(x.Instrument) ?
                 new PositionDrift(x, targetPositions[x.Instrument])
                 :
                 PositionDrift.FromFlatTargetPosition(x))
                .ToList();

        public override string? ToString()
        {
            return $"Id:{Id}, PortfolioId:{PortfolioId},PortfolioValuationId:{PortfolioValuationId}  TargetAllocationId:{TargetAllocationId}, TargetAllocationValuationId:{TargetAllocationValuationId}, NetExpoDrift:{NetExposureDrift}, GrossExpoDrift{GrossExposureDrift}";
        }

        internal IEnumerable<Order> GetOrders(RebalancingSession rebalancingSession)
            => PositionDrifts
            .Where(x => !x.QuantityDrift.IsZero())
            .Select(x => new Order(rebalancingSession.Id,
                rebalancingSession.TradeDate,
                PortfolioId,
                x.Instrument,
                x.QuantityDrift));

        public override bool Equals(object? obj)
        {
            return obj is PortfolioDrift drift &&
                   Id == drift.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }

}
