namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class RawTradeAllocation
    {
        internal int Id { get; }
        internal int TradeId { get; }
        internal byte PortfolioId { get; }
        internal Quantity Quantity { get; }
        internal Quantity OrderAllocationQuantity { get; }
        internal string PositionSide { get; }
        internal int? RebalancingId { get; }
        public RawTradeAllocation(
            int TradeAllocationId,
            int tradeId,
            byte portfolioId,
            Quantity quantity,
            Quantity orderAllocQuantity,
            string positionSide)
        {
            Id = TradeAllocationId;
            TradeId = tradeId;
            PortfolioId = portfolioId;
            Quantity = quantity;
            OrderAllocationQuantity = orderAllocQuantity;
            PositionSide = positionSide;
        }

        internal static RawTradeAllocation Create(
            int tradeId,
            byte portfolioId,
            Quantity quantity,
            Quantity orderAllocQuantity,
            string positionSide)
            => new RawTradeAllocation(0, tradeId, portfolioId, quantity, orderAllocQuantity, positionSide);

        public override string? ToString()
        {
            return $"Id:{Id} TradeId:{TradeId} PortfolId:{PortfolioId} Quantity:{Quantity}";
        }
    }
}
