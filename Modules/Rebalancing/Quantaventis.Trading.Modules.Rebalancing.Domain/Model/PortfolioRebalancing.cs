using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class PortfolioRebalancing
    {
        internal int PortfolioValuationId => PortfolioDrift.PortfolioValuationId;
        internal int TaretAllocationValuationId => PortfolioDrift.TargetAllocationValuationId;
        internal int PortfolioDriftId => PortfolioDrift.Id;
        internal PortfolioId PortfolioId => PortfolioDrift.PortfolioId;
        internal int TargetAllocationId => PortfolioDrift.TargetAllocationId;
        internal RebalancingId RebalancingId { get; }
        internal DateTime StartedOn { get; }

        internal RebalancingStatus.StatusReason StatusReason { get; }

        internal RebalancingStatus RebalancingStatus => StatusReason.Status;

        internal PortfolioDrift PortfolioDrift { get; }
        internal IEnumerable<PositionDrift> PositionDrifts => PortfolioDrift.PositionDrifts;
        internal PortfolioRebalancing(
            RebalancingId rebalancingId,
            PortfolioDrift portfolioDrift,
            DateTime startedOn, 
            RebalancingStatus.StatusReason statusReason)
        {
            RebalancingId = rebalancingId;
            PortfolioDrift = portfolioDrift;  
            StartedOn = startedOn;
            StatusReason = statusReason;

        }

   
        internal static PortfolioRebalancing Start(PortfolioDrift portfolioDrift) {
            return new PortfolioRebalancing(
                0,
                portfolioDrift,
                DateTime.UtcNow, 
                RebalancingStatus.StatusReason.Started());
        }

    }
}
