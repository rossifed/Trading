namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class TradeAllocationCorrection
    {
        internal PositionSide? PositionSide { get; }
        internal decimal? AvgPriceLocal { get; }
        internal decimal? ContractMultiplier { get; }
        internal decimal? CommissionValue { get; }
        internal string? CommissionType { get; }
        internal decimal? LocalToBaseFxRate { get; }
        internal decimal? LocalToSettleFxRate { get; }
        internal DateOnly? SettlementDate { get; }
        internal string? SettlementCurrency { get; }
        internal string? ClearingBroker { get; }
        internal string? Custodian { get; }
        internal string? PrimeBroker { get; }
        internal string? ClearingAccount { get; }
        public TradeAllocationCorrection(string? positionSide,

            decimal? avgPriceLocal,
            decimal? contractMutliplier,
            decimal? commissionValue,
            string? commissionType,
            decimal? localToBaseFxRate,
            decimal? localToSettlementFxRate,
            DateOnly? settlementDate,
            string? settlementCurrency,
            string? clearingBroker,
            string? custodian,
            string? primeBroker,
            string? clearingAccount)
        {
            PositionSide = positionSide != null?Enum.Parse<PositionSide>(positionSide): null;

            AvgPriceLocal = avgPriceLocal;
            ContractMultiplier = contractMutliplier;
            CommissionValue = commissionValue;
            CommissionType = commissionType;
            LocalToBaseFxRate = localToBaseFxRate;
            LocalToSettleFxRate = localToSettlementFxRate;
            SettlementDate = settlementDate;
            SettlementCurrency = settlementCurrency!= null? settlementCurrency: null;
            ClearingBroker = clearingBroker;
            Custodian = custodian;
            PrimeBroker = primeBroker;
            ClearingAccount = clearingAccount;
        }
        internal EnrichedTradeAllocation ApplyTo(EnrichedTradeAllocation tradeAllocation)
        {
            return new EnrichedTradeAllocation(tradeAllocation.TradeAllocationId,
              tradeAllocation.TradeId,
              tradeAllocation.PortfolioId,
              tradeAllocation.PortfolioCurrency,
              PositionSide != null ? PositionSide.Value : tradeAllocation.PositionSide,
              tradeAllocation.Quantity,
              tradeAllocation.OrderAllocationQuantity,
              AvgPriceLocal != null ? AvgPriceLocal.Value : tradeAllocation.GrossAvgPriceLocal.Amount,
              ContractMultiplier != null ? ContractMultiplier.Value : tradeAllocation.ContractMultiplier,
              new Commission(
              CommissionValue != null ? CommissionValue.Value : tradeAllocation.CommissionValue,
              CommissionType != null ? Enum.Parse<CommissionType>(CommissionType) : tradeAllocation.CommissionType),
              tradeAllocation.TradeCurrency,
              LocalToBaseFxRate != null ? LocalToBaseFxRate.Value : tradeAllocation.LocalToBaseFxRate.Value,
              LocalToSettleFxRate != null ? LocalToSettleFxRate.Value : tradeAllocation.LocalToSettleFxRate.Value,
              new TradeSettlement(SettlementCurrency != null ? SettlementCurrency : tradeAllocation.SettlementCurrency, SettlementDate != null ? SettlementDate.Value : tradeAllocation.SettlementDate),
              ClearingBroker != null ? ClearingBroker : tradeAllocation.ClearingBroker,
              Custodian != null ? Custodian : tradeAllocation.Custodian,
              PrimeBroker != null ? PrimeBroker : tradeAllocation.PrimeBroker,
              ClearingAccount != null ? ClearingAccount : tradeAllocation.ClearingAccount);
        }

    }
}
