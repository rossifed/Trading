using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class TargetWeightValuation
    {
        internal Instrument Instrument { get; }
        internal Weight Weight { get; }

        internal InstrumentPricing InstrumentPricing { get; }
        internal Money InstrumentValue { get; }
        internal Money PortfolioValue { get; }
        internal Quantity TargetQuantity { get; }
        internal Money Price { get; }

        internal DateTime PricedOn { get; }
        internal Money TargetNetExposure {get;}
        internal Money TargetGrossExposure { get; }
        internal FxRate FxRate { get; }

        public TargetWeightValuation(
            Instrument instrument,
            InstrumentPricing instrumentPricing,
            Weight weight,           
            Money instrumentValue, 
            Money portfolioValue, 
            Quantity targetQuantity, 
            Money targetNetExposure, 
            Money targetGrossExposure, 
            FxRate fxRate)
        {
            Instrument = instrument;
            Weight = weight;
            InstrumentPricing = instrumentPricing;
            InstrumentValue = instrumentValue;
            PortfolioValue = portfolioValue;
            TargetQuantity = targetQuantity;
            Price = instrumentPricing.Price;
            PricedOn = instrumentPricing.PricedOn;
            TargetNetExposure = targetNetExposure;
            TargetGrossExposure = targetGrossExposure;
            FxRate = fxRate;
        }
    }
}
