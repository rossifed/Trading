using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{
    internal class OrderAndRouteFilter : Filter
    {
        private int OrderId { get; }
        private int RouteId { get; }
        public OrderAndRouteFilter(int orderId, int routeId) : base("OrdersAndRoutes")
        {
            OrderId = orderId;
            RouteId = routeId;
        }

        protected override void SetElement(Element filterBy)
        {
            var newOrder = filterBy.GetElement("OrdersAndRoutes").AppendElement();
            newOrder.SetElement("OrderId", OrderId);
            newOrder.SetElement("RouteId", RouteId);
        }

        public override string? ToString()
        {
            return $"{Choice} OrderId:{OrderId} RouteId:{RouteId}";
        }

        public override bool Equals(object? obj)
        {
            return obj is OrderAndRouteFilter filter &&
                   base.Equals(obj) &&
                   Choice == filter.Choice &&
                   OrderId == filter.OrderId &&
                   RouteId == filter.RouteId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Choice, OrderId, RouteId);
        }
    }
}
