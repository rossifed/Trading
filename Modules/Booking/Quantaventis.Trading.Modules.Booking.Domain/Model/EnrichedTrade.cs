namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class EnrichedTrade
    {
        internal string ExecutionChannel { get; }
        internal int? RebalancingId { get; }
        internal int TradeId { get; }
        internal Money Principal { get; }
        internal Money TradeValue { get; }
        internal string Symbol => InstrumentIdentifiers.Symbol;
        internal Currency TradeCurrency { get; }
        internal int InstrumentId { get; }
        internal Money AvgPrice { get; }
        internal Quantity Quantity { get; }
        internal string ExecutionBroker { get; }
        internal decimal ContractMultiplier { get; }
        internal Account ExecutionAccount { get; }
        internal DateOnly TradeDate { get; }
        internal Exchange Exchange { get; }
        internal InstrumentIdentifiers InstrumentIdentifiers { get; }
        internal OrderDetails OrderDetails { get; }
        internal FillsDetails FillsDetails { get; }
        internal TradeSide TradeSide { get; }
        internal string ExecutionDesk { get; set; }
        internal DateOnly? SettlementDate { get; }
        internal string InstrumentType { get; }
        internal DateTime TradeDateTime => TradeDate.ToDateTime(TimeOnly.MinValue);
        internal string TradeInstrumentType { get; }
        internal bool IsSwap { get; }
        internal string ExecutionType { get; }
        internal decimal NominalQuantity { get; }
        internal decimal PriceScalingFactor { get; }
        internal EnrichedTrade(int tradeId,
            int? rebalancingId,
            TradeSide tradeSide,
            Instrument instrument,
            Quantity quantity,
            TradeInstrumentType tradeInstrumentType,
            Money avgPriceLocal,
            string executionChannel,
            string executionDesk,
            Counterparty executionBroker,
            Account executionAccount,
            DateOnly tradeDate,
            Exchange exchange,
            DateOnly? settlementDate,
            ExecutionType executionType,
            InstrumentIdentifiers instrumentIdentifiers,
            OrderDetails orderDetails,
            FillsDetails fillsDetails) : this(tradeId,
                rebalancingId,
                tradeSide,
                instrument.Id,
                quantity,
                avgPriceLocal,
                tradeDate,
                instrument.InstrumentType,
                tradeInstrumentType.Mnemonic,
                tradeInstrumentType.IsSwap,
                exchange,
                executionChannel,
                executionDesk,
                executionBroker.Code,
                executionAccount.Code,
                executionType.Code,
                instrument.ContractMultiplier,
                settlementDate,
                instrument.PriceScalingFactor,
                instrumentIdentifiers,
                orderDetails,
                fillsDetails
                )
        {

        }



        internal EnrichedTrade(
        int tradeId,
        int? rebalancingId,
        TradeSide tradeSide,
        int instrumentId,
        Quantity quantity,
        Money avgPrice,
        DateOnly tradeDate,
        string instrumentType,
        string tradeInstrumentType,
        bool isSwap,
        Exchange exchange,
        string executionChannel,
        string executionDesk,
        string executionBroker,
        string executionAccount,
        string executionType,
        decimal contractMultiplier,
        DateOnly? settlementDate,
        decimal priceScalingFactor,
        InstrumentIdentifiers instrumentDetails,
        OrderDetails orderDetails,
        FillsDetails fillsDetails)
        {
            this.TradeId = tradeId;
            this.RebalancingId = rebalancingId;
            this.TradeSide = tradeSide;
            this.InstrumentId = instrumentId;
            this.TradeCurrency = avgPrice.Currency;
            this.AvgPrice = avgPrice;
            this.Quantity = quantity.AdjustSign(tradeSide);
            this.InstrumentType = instrumentType;
            this.TradeInstrumentType = tradeInstrumentType;
            this.IsSwap = isSwap;
            this.ContractMultiplier = contractMultiplier;
            this.NominalQuantity = Quantity * ContractMultiplier;
            this.TradeValue = AvgPrice * Quantity;
            this.Principal = AvgPrice * NominalQuantity;
            this.ExecutionChannel = executionChannel;
            this.ExecutionDesk = executionDesk;
            this.ExecutionBroker = executionBroker;
            this.ExecutionAccount = executionAccount;
            this.TradeDate = tradeDate;
            this.Exchange = exchange;
            this.ExecutionType = executionType;
            this.InstrumentIdentifiers = instrumentDetails;
            this.OrderDetails = orderDetails;
            this.FillsDetails = fillsDetails;
            this.SettlementDate = settlementDate;
            this.PriceScalingFactor = priceScalingFactor;
        }


        public override string? ToString()
        {
            return $"{TradeId}:{TradeSide} {Quantity} {Symbol} {AvgPrice} {TradeDate.ToString("yyyyMMdd")}";
        }

        public override bool Equals(object? obj)
        {
            return obj is EnrichedTrade trade &&
                   TradeId == trade.TradeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TradeId);
        }
    }
}
