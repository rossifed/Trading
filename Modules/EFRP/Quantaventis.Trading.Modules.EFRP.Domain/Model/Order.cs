namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class Order : IEfrpCandidate
    {
        internal int OrderId{get;}
        public int InstrumentId { get; }
        public int BrokerId { get; }
        internal int Quantity { get; }
        internal string TradingDesk { get; }

        internal string TradingAccount { get; }

        internal string ExecutionChannel { get; }
        internal byte PortfolioId { get; }
        internal int? RebalancingId { get; }
        internal string PositionSide { get; }
        internal string OrderReason { get; }
        public Order(int orderId, 
            int instrumentId, 
            int brokerId, 
            int quantity, 
            string tradingDesk, 
            string tradingAccount,
            byte portfolioId,
            int? rebalancingId,
            string positionSide,
            string orderReason)
        {
            OrderId = orderId;
            InstrumentId = instrumentId;
            BrokerId = brokerId;
            Quantity = quantity;
            TradingDesk = tradingDesk;
            TradingAccount = tradingAccount;
            RebalancingId = rebalancingId;
            PortfolioId = portfolioId;
            PositionSide = positionSide;
            OrderReason = orderReason;
        }

        internal FutureContractOrder ToFutureContractOrder(FutureContract futureContract) {
            if (futureContract.Id == InstrumentId)
                return new FutureContractOrder(
                    OrderId,
                    futureContract, 
                    BrokerId,
                    Quantity,
                    TradingDesk,
                    TradingAccount,
                    PortfolioId,
                    RebalancingId,
                    PositionSide,
                    OrderReason);
            throw new InvalidOperationException($"Order {this} can't be converted. The futureContract {futureContract} doesn't match the Instrument {InstrumentId}");
        
        }
        
    }
}
