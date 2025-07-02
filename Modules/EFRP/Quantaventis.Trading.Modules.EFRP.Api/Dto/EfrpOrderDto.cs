namespace Quantaventis.Trading.Modules.EFRP.Api.Dto
{
    public class EfrpOrderDto
    {
        public int OriginalOrderId { get; set; }

        public string Symbol { get; set; }
        public string BaseCurrency { get; set; }
        public string QuoteCurrency { get; set; }
        public DateOnly ValueDate { get; set; }

        public long Quantity { get; set; }
        public String TradingDesk { get; set; }

        public string TradingAccount { get; set; }

        public byte PortfolioId { get; set; }

        public int? RebalancingId { get; set; }
        public string PositionSide { get; set; }

        public string OrderReason { get; set; }
    }
}
