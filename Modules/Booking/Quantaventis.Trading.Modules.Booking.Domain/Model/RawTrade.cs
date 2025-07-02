namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class RawTrade
    {
        internal int TradeId { get; }
        internal string Symbol { get; }
        internal int? EmsxOrderId => OrderDetails.EmsxOrderId;
        internal int? OrderReferenceId => OrderDetails.OrderReferenceId;
        internal string ExecutionChannel { get; }
        internal string Side { get; }
        internal int Quantity { get; }
        internal decimal AvgPrice { get; }
        internal string Currency { get; }
        internal DateOnly TradeDate { get; }
        internal string Exchange { get; }
        internal string ExecutionDesk { get; }
        internal string ExecutionAccount { get; }
        internal bool IsCfd { get; }
        internal string? StrategyType => OrderDetails.StrategyType;
        internal DateOnly? SettlementDate { get; set; }
        internal InstrumentIdentifiers InstrumentIdentifiers { get; set; }
        internal OrderDetails OrderDetails { get; set; }
        internal FillsDetails FillsDetails { get; set; }
        internal RawTrade(int tradeId,
         string symbol,
         string side,
         int quantity,
         decimal avgPrice,
         string currency,
         DateOnly tradeDate,
         string exchange,
         string broker,
         string account,
         bool isCfd,
         string executionChannel,
         DateOnly? settlementDate,
         InstrumentIdentifiers instrumentIdentifiers,
         OrderDetails orderDetails,
         FillsDetails fillsDetails)
        {
            this.TradeId = tradeId;
            this.Symbol = symbol;
            this.Side = side;
            this.Quantity = quantity;
            this.AvgPrice = avgPrice;
            this.Currency = currency;
            this.TradeDate = tradeDate;
            this.Exchange = exchange;
            this.ExecutionDesk = broker;
            this.SettlementDate = settlementDate;
            this.ExecutionAccount = account;
            this.IsCfd = isCfd;
            this.ExecutionChannel = executionChannel;
            this.InstrumentIdentifiers = instrumentIdentifiers;
            this.OrderDetails = orderDetails;
            this.FillsDetails = fillsDetails;
        }

        public override bool Equals(object? obj)
        {
            return obj is RawTrade trade &&
                   TradeId == trade.TradeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TradeId);
        }

        public override string? ToString()
        {
            return $"Id:{TradeId} {Side} {Quantity} {Symbol} {TradeDate.ToString("yyyyMMdd")}";
        }
    }
}
