namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class InstrumentPricing
    {
        public InstrumentPricing(InstrumentId instrumentId, Money price, DateTime pricingTime)
        {
            InstrumentId = instrumentId;
            Price = price;

            PricedOn = pricingTime;

        }

        internal InstrumentId InstrumentId { get; }

        internal Money Price { get; }

        internal Currency Currency => Price.Currency;
        internal DateTime PricedOn { get; }

        public override bool Equals(object? obj)
        {
            return obj is InstrumentPricing pricing &&
                   EqualityComparer<InstrumentId>.Default.Equals(InstrumentId, pricing.InstrumentId) &&
                   EqualityComparer<Money>.Default.Equals(Price, pricing.Price) &&
                   EqualityComparer<Currency>.Default.Equals(Currency, pricing.Currency) &&
                   PricedOn == pricing.PricedOn;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(InstrumentId, Price, Currency, PricedOn);
        }
    }
}
