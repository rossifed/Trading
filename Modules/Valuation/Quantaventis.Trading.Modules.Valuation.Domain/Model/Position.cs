using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class Position
    {  
        internal Instrument Instrument { get; }
        internal Quantity Quantity { get; }
        internal AverageEntryCost AverageEntryCost { get; }
        internal Money AverageEntryPrice => AverageEntryCost.AverageEntryPriceLocal;
        internal FxRate AverageEntryFxRate => AverageEntryCost.AverageEntryFxRate;

        public Position(Instrument instrument, 
            Quantity quantity, 
            AverageEntryCost averageEntryCost)
        {
            Instrument = instrument;
            Quantity = quantity;
            AverageEntryCost = averageEntryCost;
        }

        internal PositionValuation Valuate(ValuationContext valuationContext, Money totalPortfolioValue)
        {
            var instrumentPricing = valuationContext.GetPricing(Instrument);
           
                _ = instrumentPricing ?? throw new InvalidOperationException($"Pricing not found for the Instrument: {Instrument}");
                var fxRate = valuationContext.GetFxRate(instrumentPricing.Currency);
                var instrumentValue = ValuateInstrument(instrumentPricing.Price, fxRate);
                var netExposure = ComputeNetExposure(instrumentValue);
                var grossExposure = netExposure.Abs();
                var avgEntryNetExposure = ComputeNetExposure(AverageEntryPrice, fxRate);
                var pnl = netExposure - avgEntryNetExposure;
                var roi = avgEntryNetExposure.Amount != 0m ? (netExposure - avgEntryNetExposure) / avgEntryNetExposure : Money.Zero(avgEntryNetExposure.Currency);
                var weight = new Weight((netExposure / totalPortfolioValue).Amount);
                return new PositionValuation(
                   this,
                   instrumentPricing,
                   instrumentValue,
                   fxRate,
                   weight,
                   netExposure,
                   grossExposure,
                   pnl,
                   roi);
          
        }
   
        internal Money ValuateInstrument(ValuationContext valuationContext)
        {
            Money price = valuationContext.GetPrice(Instrument);
            FxRate fxRate = valuationContext.GetFxRate(price.Currency);
            return ValuateInstrument(price, fxRate);
        }

        internal Money ValuateInstrument(Money price, FxRate fxRate)
        {
        
            return Instrument.Valuate(price) * fxRate;
        }

        internal Money ComputeNetExposure(Money price, FxRate fxRate)
                   => ValuateInstrument(price, fxRate) * Quantity;
        internal Money ComputeNetExposure(Money instrumentValue)
                => instrumentValue * Quantity;

    }
}
