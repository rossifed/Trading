namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class FutureContract : Instrument
    {
        internal Money PointValue { get; }

        public FutureContract(
            InstrumentId id,
            Money pointValue) : base(id)
        {
            this.PointValue = pointValue;
        }

        internal override Money Valuate(Money price)
         => price * PointValue;
    }
}
