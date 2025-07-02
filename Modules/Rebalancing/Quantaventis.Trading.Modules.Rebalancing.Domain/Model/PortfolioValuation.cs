using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class PortfolioValuation
    {
        internal int Id { get; }
        internal PortfolioId PortfolioId { get; }
        internal Money PortfolioValue { get; }
        internal Weight NetExposure { get; }
        internal Weight GrossExposure { get; }
        internal DateTime ValuatedOn { get; }
        internal IEnumerable<InvestedPosition> Positions { get; }

        public PortfolioValuation(
            int id,
            PortfolioId portfolioId,
            Money portfolioValue, 
            Weight netExposure, 
            Weight grossExposure, 
            DateTime valuatedOn,
            IEnumerable<InvestedPosition> positions)
        {
            Id = id;
            PortfolioId = portfolioId;
            PortfolioValue = portfolioValue;
            NetExposure = netExposure;
            GrossExposure = grossExposure;
            Positions = positions;
            ValuatedOn = valuatedOn;
        }


        //internal static PortfolioValuation Flat(int id PortfolioId portfolioId, Money portfolioValue)
        //    => new PortfolioValuation(portfolioId, portfolioValue, 0, 0, Enumerable.Empty<InvestedPosition>());

  

        public override string? ToString()
        {
            return Id.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is PortfolioValuation valuation &&
                   Id == valuation.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
