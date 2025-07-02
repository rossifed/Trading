using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class ValuationContext
    {
        internal Money PortfolioValue { get; }

        internal Currency ValuationCurrency { get; }

        internal IDictionary<Currency, FxRate> FxRates { get; }

        internal IDictionary<InstrumentId, InstrumentPricing> Pricings { get; }

        internal ValuationContext(
            Currency valuationCurrency,
            IDictionary<Currency, FxRate> fxRates, 
            IDictionary<InstrumentId, InstrumentPricing> pricings)
        {
            ValuationCurrency = valuationCurrency;
            FxRates = fxRates;
            Pricings = pricings;
        }
        internal ValuationContext(
               Currency valuationCurrency,
        IEnumerable<FxRate> fxRates,
        IEnumerable<InstrumentPricing> pricings): this(valuationCurrency,
            fxRates.ToDictionary(x=>x.BaseCurrency),
            pricings.ToDictionary(x =>x.InstrumentId)
            )
        {

        }
        internal bool IsValuationCurrency(Currency currency)
            => ValuationCurrency == currency;
        internal InstrumentPricing GetPricing(Instrument instrument)
        {
            if (Pricings.ContainsKey(instrument.Id))
                return Pricings[instrument.Id];

            throw new InvalidOperationException($"ValuationContext doesn't have any Pricing for the instrument {instrument.Id}");
       
        }

        internal Money GetPrice(Instrument instrument)
        {
            InstrumentPricing pricing = GetPricing(instrument);
            return pricing.Price;
        }
        internal FxRate GetFxRate(Currency currency)
        {
            if (currency == ValuationCurrency)
                return new FxRate(1, currency, ValuationCurrency);
            if(FxRates.ContainsKey(currency))
                return FxRates[currency];

            throw new InvalidOperationException($"ValuationContext dosesn't have FX Rate for currency pair {currency}{ValuationCurrency}");
        }

        //internal FxRate? GetFxRate(Instrument instrument)
        //{
        //    return GetFxRate(instrument.Currency);
        //}

    }
}
