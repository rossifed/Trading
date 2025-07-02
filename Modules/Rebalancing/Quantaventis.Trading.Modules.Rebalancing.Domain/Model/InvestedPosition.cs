namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class InvestedPosition
    {
        internal Instrument Instrument;
        internal Quantity Quantity { get; }
        internal Weight Weight { get; }



        internal InvestedPosition (Instrument instrument, Quantity quantity, Weight weight)
        {
            Instrument = instrument;
            Quantity = quantity;
            Weight = weight;
        }

        internal static InvestedPosition Flat(Instrument instrument) 
            => new InvestedPosition(instrument, 0, 0);

        public override bool Equals(object? obj)
        {
            return obj is InvestedPosition position &&
                   EqualityComparer<Instrument>.Default.Equals(Instrument, position.Instrument);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Instrument);
        }

        public override string? ToString()
        {
            return $"{Instrument} {Quantity}, {Weight}";
        }
    }
}
