namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class Equity : Instrument
    {
        internal Equity(InstrumentId id) 
            : base(id)
        {
        }

        internal override Money Valuate(Money price)
         => price;

    }
}
