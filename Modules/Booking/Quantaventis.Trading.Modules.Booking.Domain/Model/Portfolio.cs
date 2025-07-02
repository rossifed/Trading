namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class Portfolio
    {
        internal byte Id { get; }
        internal Currency Currency { get; }

        public override bool Equals(object? obj)
        {
            return obj is Portfolio portfolio &&
                   Id == portfolio.Id;
        }

        public override string? ToString()
        {
            return Id.ToString();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public Portfolio(byte id, Currency currency)
        {
            Id = id;
            Currency = currency;
        
        }
    }
}
