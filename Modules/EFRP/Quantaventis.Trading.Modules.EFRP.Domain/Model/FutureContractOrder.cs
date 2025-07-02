namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class FutureContractOrder : Order
    {

        internal FutureContract FutureContract { get; }

        public FutureContractOrder(int orderId,
       FutureContract futureContract,
       int brokerId,
       int quantity,
       string tradingDesk,
       string tradingAccount,
           byte portfolioId,
            int? rebalancingId,
            string positionSide,
            string orderReason)
            : base(orderId,
                 futureContract.Id,
                 brokerId,
                 quantity,
                 tradingDesk,
                 tradingAccount,
                 portfolioId,
                 rebalancingId,
                 positionSide,
                 orderReason)
        {
            FutureContract = futureContract;
        }


    }
}
