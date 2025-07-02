namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class InstrumentValuation
    {


      internal  Instrument Instrument { get; }
        
        internal DateTime ValuatedOn { get; }

        internal Money Value { get; }

        internal Currency Currency => Value.Currency;
      


        internal InstrumentValuation Apply(FxRate fxRate) {
            if (fxRate.BaseCurrency != Currency)
                throw new ArgumentException($"FxRate {fxRate} can't be applied to Instrument Valuation {this}. FxRate base currency {fxRate.BaseCurrency} is not equal to the instrument valuation currency {Currency} ");
            return new InstrumentValuation(Instrument,
                Value * fxRate,
                ValuatedOn);
        }

        internal InstrumentValuation(Instrument instrument,  Money value, DateTime valuatedOn)
        {
            Instrument = instrument;
            Value = value;
            ValuatedOn = valuatedOn;

        }
    }
}
