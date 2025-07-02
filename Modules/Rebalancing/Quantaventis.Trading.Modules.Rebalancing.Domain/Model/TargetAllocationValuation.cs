using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class TargetAllocationValuation
    {
        internal int Id { get; }
        internal int TargetAllocationId { get; }
        internal PortfolioId PortfolioId { get; }
        internal Money PortfolioValue { get; }
        internal Weight NetExposure { get; }
        internal Weight GrossExposure { get; }
        
        internal DateTime ValuatedOn { get; }
        internal IEnumerable<TargetPosition> TargetPositions { get; }

        public TargetAllocationValuation(
            int id,
            int targetAllocationId,
            PortfolioId portfolioId,
            Money portfolioValue, 
            Weight netExposure, 
            Weight grossExposure, 
            DateTime valuatedOn,
            IEnumerable<TargetPosition> targetPositions)
        {
            Id = id;
            TargetAllocationId = targetAllocationId;
            PortfolioId = portfolioId;
            PortfolioValue = portfolioValue;
            NetExposure = netExposure;
            GrossExposure = grossExposure;
            TargetPositions = targetPositions;
            ValuatedOn = valuatedOn;
        }

  


        public override string? ToString()
        {
            return Id.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is TargetAllocationValuation valuation &&
                   Id == valuation.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
