namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal abstract  class Instrument
    {

        internal InstrumentId Id { get; }




        internal Instrument(
            InstrumentId instrumentId)
        {
            this.Id = instrumentId;

        }

        internal abstract Money Valuate(Money price);


        public override bool Equals(object? obj)
        {
            return obj is Instrument instrument &&
                   EqualityComparer<InstrumentId>.Default.Equals(Id, instrument.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return Id.ToString();
        }
    }
}
