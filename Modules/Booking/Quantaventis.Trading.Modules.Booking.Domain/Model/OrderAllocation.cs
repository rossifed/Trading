namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class OrderAllocation
    {
        internal int OrderId { get; }
        internal byte PortfolioId { get; }
        internal int Quantity { get; }
        internal string PositionSide { get; }
        public OrderAllocation(
            int orderId,
            byte portfolioId,
            int quantity,
            string side)
        {
            OrderId = orderId;
            PortfolioId = portfolioId;
            Quantity = quantity;
            PositionSide = side;
        }

        public override string? ToString()
        {
            return $"Id:{OrderId}, PortfolioId:{PortfolioId}, Quantity:{Quantity}";
        }

        public override bool Equals(object? obj)
        {
            return obj is OrderAllocation allocation &&
                   OrderId == allocation.OrderId &&
                   PortfolioId == allocation.PortfolioId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId, PortfolioId);
        }
    }

}
