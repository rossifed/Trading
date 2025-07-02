using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class TargetAllocation
    {
        internal int Id { get; }
        internal PortfolioId PortfolioId { get; }
        internal DateTime GeneratedOn { get; }
        internal IEnumerable<TargetWeight> TargetWeights { get; }

        public TargetAllocation(int id,PortfolioId portfolioId, DateTime generatedOn, IEnumerable<TargetWeight> targetWeights)
        {
            Id = id;
            PortfolioId = portfolioId;
            GeneratedOn = generatedOn;
            TargetWeights = targetWeights;
        }

        internal TargetAllocationValuation Valuate(ValuationContext valuationContext, Money portfolioValue) {
            IEnumerable<TargetWeightValuation> targetWeightValuations = ValuateTargetWeights(valuationContext, portfolioValue);
            var valuationCurrency = valuationContext.ValuationCurrency;
            var totalNetExposure = Money.Zero(valuationCurrency);
            var totalGrossExposure = Money.Zero(valuationCurrency);
            decimal totalWeight = 0;
            foreach (TargetWeightValuation targetWeightValuation in targetWeightValuations) {
                totalNetExposure += targetWeightValuation.TargetNetExposure;
                totalGrossExposure += targetWeightValuation.TargetGrossExposure;
                totalWeight += targetWeightValuation.Weight;
                
            }

            return new TargetAllocationValuation(
                this,
                portfolioValue,
                totalNetExposure,
                totalGrossExposure,
                totalWeight,
                targetWeightValuations,
                DateTime.UtcNow
                );
        }

        internal IEnumerable<TargetWeightValuation> ValuateTargetWeights(ValuationContext valuationContext, Money portfolioValue)
         => TargetWeights.Select(x => x.Valuate(valuationContext, portfolioValue));
        
    }
}
