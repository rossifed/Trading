using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{
    internal class BasketFilter : Filter
    {
        private IEnumerable<string> Baskets { get; }
        public BasketFilter(IEnumerable<string> baskets) : base("Basket")
        {
            Baskets = baskets;
        }

        protected override void SetElement(Element filterBy)
        {
            Element basketElement = filterBy.GetElement("Basket");

            foreach (var basket in Baskets)
            {
                basketElement.AppendValue(basket);

            }
        }

        public override string? ToString()
        {
            return $"{Choice}:{string.Join(',', Baskets)}";
        }

        public override bool Equals(object? obj)
        {
            return obj is BasketFilter filter &&
                   base.Equals(obj) &&
                   Choice == filter.Choice &&
                   EqualityComparer<IEnumerable<string>>.Default.Equals(Baskets, filter.Baskets);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Choice, Baskets);
        }
    }
}
