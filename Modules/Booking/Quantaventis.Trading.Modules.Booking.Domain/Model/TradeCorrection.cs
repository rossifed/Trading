namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class TradeCorrection
    {
        internal decimal? AvgPriceLocal { get; }
        internal string? TradeInstrumentType { get; }
        internal decimal? ContractMultiplier { get; }
        internal bool? IsSwap { get; }
        internal string? ExecutionBroker { get; }
        internal string? ExecutionAccount { get; }
        internal string? Exchange { get; }
        internal string? ExecutionType { get; }
        internal DateOnly? TradeDate { get; }
        public TradeCorrection(decimal? avgPriceLocal,
            string? tradeInstrumentType,
            bool? isSwap,
            decimal? contractMultiplier,
            string? executionBroker,
            Account? executionAccount,
            Exchange? exchange,
            string? executionType,
            DateOnly? tradeDate)
        {
            AvgPriceLocal = avgPriceLocal;
            ContractMultiplier = contractMultiplier;
            TradeInstrumentType = tradeInstrumentType;
            IsSwap = isSwap;
            ExecutionBroker = executionBroker;
            ExecutionAccount = executionAccount;
            Exchange = exchange;
            ExecutionType = executionType;
            TradeDate = tradeDate;
        }

        internal EnrichedTrade ApplyTo(EnrichedTrade trade)
        {

            return new EnrichedTrade(trade.TradeId,
                trade.RebalancingId,
            trade.TradeSide,
            trade.InstrumentId,
            trade.Quantity,
            AvgPriceLocal != null ? new Money(AvgPriceLocal.Value, trade.TradeCurrency) : trade.AvgPrice,
             TradeDate != null ? TradeDate.Value : trade.TradeDate,
             trade.TradeInstrumentType,
            TradeInstrumentType != null ? TradeInstrumentType : trade.TradeInstrumentType,
            IsSwap != null ? IsSwap.Value : trade.IsSwap,
            Exchange != null ? Exchange : trade.Exchange,
            trade.ExecutionChannel,
            trade.ExecutionDesk,
            ExecutionBroker != null ? ExecutionBroker : trade.ExecutionBroker,
            ExecutionAccount != null ? ExecutionAccount : trade.ExecutionAccount,
            ExecutionType != null ? ExecutionType : trade.ExecutionType,
            ContractMultiplier != null ? ContractMultiplier.Value : trade.ContractMultiplier,

            trade.SettlementDate,
            trade.PriceScalingFactor,
            trade.InstrumentIdentifiers,
            trade.OrderDetails,
            trade.FillsDetails);
        }

        internal TradeAllocationCorrection ToTradeAllocationCorrection(EnrichedTradeAllocation alloc)
        {

            return new TradeAllocationCorrection(alloc.PositionSide.ToString(),
            AvgPriceLocal,
            ContractMultiplier,
            alloc.CommissionValue, 
            alloc.CommissionType.ToString(),
             alloc.LocalToBaseFxRate.Value,
             alloc.LocalToSettleFxRate.Value,
             alloc.SettlementDate,
             alloc.SettlementCurrency,
             alloc.ClearingBroker,
             alloc.Custodian,
             alloc.PrimeBroker,
             alloc.ClearingAccount);
        }
    }
}
