namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class FxForward : Instrument
    {

        internal FxForward(InstrumentId id) : base(id)
        {
    
        }

        internal override Money Valuate(Money price)
         => price;


  
    }
}
