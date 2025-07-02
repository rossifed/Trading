using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class TargetAllocationValuation
    {

        internal PortfolioId PortfolioId => TargetAllocation.PortfolioId;
        internal TargetAllocation TargetAllocation { get; }
        internal Money PortfolioValue { get; }
        internal Money TargetNetExposure { get; }
        internal Currency ValuationCurrency { get; }
        internal Money TargetGrossExposure { get; }
        internal decimal TotalWeight { get; }
      
        internal DateTime ValuatedOn { get; }
        internal IEnumerable<TargetWeightValuation> TargetWeightValuations { get; }

        
        public TargetAllocationValuation(
            TargetAllocation targetAllocation, 
            Money portfolioValue, 
            Money targetNetExposure, 
            Money targetGrossExposure, 
            decimal totalWeight, 
            IEnumerable<TargetWeightValuation> targetWeightValuations,
            DateTime valuatedOn)
        {
            TargetAllocation = targetAllocation;
            PortfolioValue = portfolioValue;
            TargetNetExposure = targetNetExposure;
            TargetGrossExposure = targetGrossExposure;
            TotalWeight = totalWeight;
            TargetWeightValuations = targetWeightValuations;
            ValuatedOn = valuatedOn;
            ValuationCurrency = portfolioValue.Currency;
        }
    }
}
