using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{
    internal class OrdersFilter : Filter
    {
        private IEnumerable<int> OrderIds { get; }
        public OrdersFilter(int orderId) : this(new List<int>() { orderId})
        {
      
        }
        public OrdersFilter(IEnumerable<int> orderIds) : base("OrdersAndRoutes")
        {
            OrderIds= orderIds;
        }

        protected override void SetElement(Element filterBy)
        {
         
            foreach (int orderId in OrderIds)
            {
                var newOrder = filterBy.GetElement("OrdersAndRoutes").AppendElement();
                newOrder.SetElement("OrderId", orderId);
            }
      
        }

        public override string? ToString()
        {
            return $"{Choice} OrdersFilter";
        }

        public override bool Equals(object? obj)
        {
            return obj is OrdersFilter filter &&
                   base.Equals(obj) &&
                   Choice == filter.Choice &&
                   EqualityComparer<IEnumerable<int>>.Default.Equals(OrderIds, filter.OrderIds);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Choice, OrderIds);
        }
    }
}
