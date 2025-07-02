namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class Order
    {
        internal int Id { get; }
        internal int? RebalancingId { get; }
        internal int InstrumentId { get; }
        internal string Symbol { get; }
        internal int Quantity { get; }
        internal DateOnly TradeDate { get; }
        internal string TradeMode { get; }
        internal string OrderType { get; }
        internal string ExecutionAlgo { get; }
        internal string TimeInForce { get; }
        internal string ExecutionDesk { get; }
        internal string ExectionAccount { get; }
        internal IEnumerable<OrderAllocation> OrderAllocations { get; }

        public Order(int id,
            int? rebalancingId,
            int instrumentId,
            string symbol,
            int quantity,
            DateOnly tradeDate,
            string tradeMode,
            string orderType,
            string executionAlgo,
            string timeInForce,
            string executionDesk,
            string exectionAccount,
            IEnumerable<OrderAllocation> orderAllocations)
        {
            Id = id;
            RebalancingId = rebalancingId;
            InstrumentId = instrumentId;
            Symbol = symbol;
            Quantity = quantity;
            TradeDate = tradeDate;
            TradeMode = tradeMode;
            OrderType = orderType;
            ExecutionAlgo = executionAlgo;
            TimeInForce = timeInForce;
            ExecutionDesk = executionDesk;
            ExectionAccount = exectionAccount;
            OrderAllocations = orderAllocations;
        }

        internal bool IsEfrp => TradeMode.Trim().ToUpper().Equals("EFRP");
        public override string? ToString()
        {
            return $"OrderId:{Id} Symbol:{Symbol} Quantity:{Quantity} TradeDate:{TradeDate.ToString("yyyyMMdd")}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Order order &&
                   Id == order.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }

}
