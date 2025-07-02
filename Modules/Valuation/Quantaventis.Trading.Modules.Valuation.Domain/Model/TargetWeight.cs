using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class TargetWeight
    {
        internal Instrument Instrument { get; }
        internal Weight Weight { get; }

        public TargetWeight(Instrument instrument, Weight weight)
        {
            Instrument = instrument;
            Weight = weight;
        }

        internal TargetWeightValuation Valuate(ValuationContext valuationContext, Money portfolioValue) {
            try
            {
                var instrumentPricing = valuationContext.GetPricing(Instrument);
                var fxRate = valuationContext.GetFxRate(instrumentPricing.Currency);
                var instrumentValue = Instrument.Valuate(instrumentPricing.Price) * fxRate;
                var targetNetExposure = Weight * portfolioValue;
                var targetGrossExposure = targetNetExposure.Abs();
                var targetQuantity = Convert.ToInt32(Math.Truncate((targetNetExposure / instrumentValue).Amount));
            
            return new TargetWeightValuation(
                Instrument,
                instrumentPricing,
                Weight,
                instrumentValue,
                portfolioValue,
                targetQuantity,
                targetNetExposure,
                targetGrossExposure,
                fxRate
                );
            }
            catch (Exception ex)
            {

           
            } return null;
        }
    }
}
