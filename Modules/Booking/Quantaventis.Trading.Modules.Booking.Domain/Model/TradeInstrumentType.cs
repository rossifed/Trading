namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class TradeInstrumentType
    {
        internal int Id { get; }
        internal string Mnemonic { get; }
        internal string Name { get; }
        internal string InstrumentType { get; }
        internal bool IsSwap { get; }

        internal TradeInstrumentType(int id,
            string mnemonic,
            string name,
            string instrumentType,
            bool isSwap)
        {
            Id = id;
            Mnemonic = mnemonic;
            Name = name;
            InstrumentType = instrumentType;
            IsSwap = isSwap;
        }

        public override string? ToString()
        {
            return Mnemonic;
        }
        public override bool Equals(object? obj)
        {
            return obj is TradeInstrumentType type &&
                   Id == type.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
