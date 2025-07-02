namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class EnrichedTradeAllocation
    {
        internal int TradeAllocationId { get; }
        internal int TradeId { get; }
        internal Money GrossAvgPriceLocal { get; }

        internal Money PriceCommissionLocal { get; }
        internal Money PriceCommissionBase { get; }
        internal Money PriceCommissionSettle { get; }
        internal Money GrossAvgPriceBase { get; }
        internal Money GrossAvgPriceSettle { get; }
        internal Money NetAvgPriceLocal { get; }
        internal Money NetAvgPriceBase { get; }
        internal Money NetAvgPriceSettle { get; }
        internal Money GrossPrincipalLocal { get; }
        internal Money GrossPrincipalBase { get; }
        internal Money? GrossPrincipalSettle { get; }
        internal Money NetPrincipalLocal { get; }
        internal CommissionType CommissionType => Commission.CommissionType;
        internal decimal CommissionValue => Commission.Value;

        internal Money MiscFeesAmountLocal { get; }
        internal Money MiscFeesAmountSettle { get; }
        internal Money MiscFeesAmountBase { get; }
        internal Money NetPrincipalBase { get; }
        internal Money NetPrincipalSettle { get; }
        internal Money CommissionAmountLocal { get; }
        internal Money CommissionAmountBase { get; }
        internal Money CommissionAmountSettle { get; }
        internal Money GrossTradeValueLocal { get; }
        internal Money GrossTradeValueBase { get; }
        internal Money GrossTradeValueSettle { get; }
        internal Money NetTradeValueLocal { get; }
        internal Money NetTradeValueBase { get; }
        internal Money NetTradeValueSettle { get; }
        internal Currency TradeCurrency { get; }
        internal decimal NominalQuantity { get; }
        internal decimal OrderAllocationNominalQuantity { get; }
        internal FxRate LocalToBaseFxRate { get; }
        internal FxRate LocalToSettleFxRate { get; }
        internal Account ClearingAccount { get; }
        internal PositionSide PositionSide { get; }
        internal Commission Commission { get; }
        internal Quantity Quantity { get; }
        internal Quantity OrderAllocationQuantity { get; }
        internal decimal ContractMultiplier { get; }
        internal Currency SettlementCurrency { get; }
        internal DateOnly SettlementDate { get; }
        internal TradeSettlement TradeSettlement { get; }
        internal byte PortfolioId { get; }
        internal Currency PortfolioCurrency { get; }
        internal string ClearingBroker { get; }
        internal string? Custodian { get; }
        internal string? PrimeBroker { get; }
        internal EnrichedTradeAllocation(
             int tradeAllocationId,
             int tradeId,
             byte portfolioId,
             Currency portfolioCurrency,
             PositionSide positionSide,
             Quantity quantity,
             Quantity orderAllocationQuantity,
             decimal avgPriceLocal,
             decimal contractMutliplier,
             Commission commission,
             Currency localCurrency,
             decimal localToBaseFxRate,
             decimal localToSettlementFxRate,
             TradeSettlement tradeSettlement,
             string clearingBroker,
             string? custodian,
             string? primeBroker,
             Account clearingAccount
         )
        {
            this.TradeId = tradeId;
            this.TradeAllocationId = tradeAllocationId;
            this.PositionSide = positionSide;
            this.PortfolioId = portfolioId;
            this.PortfolioCurrency = portfolioCurrency;
            this.Commission = commission;
            this.SettlementCurrency = tradeSettlement.SettlementCurrency;
            this.SettlementDate = tradeSettlement.SettlementeDate;
            this.LocalToBaseFxRate = new FxRate(localToBaseFxRate, localCurrency, portfolioCurrency);
            this.LocalToSettleFxRate = new FxRate(localToSettlementFxRate, localCurrency, SettlementCurrency);
            this.OrderAllocationQuantity = orderAllocationQuantity;
            this.OrderAllocationNominalQuantity = OrderAllocationQuantity * contractMutliplier;
            this.Quantity = quantity;
            this.TradeSettlement = tradeSettlement;
            this.ContractMultiplier = contractMutliplier;
            this.NominalQuantity = Quantity * contractMutliplier;
            this.GrossAvgPriceLocal = new Money(avgPriceLocal, localCurrency);
            this.GrossAvgPriceBase = GrossAvgPriceLocal * LocalToBaseFxRate;
            this.GrossAvgPriceSettle = GrossAvgPriceLocal * LocalToSettleFxRate;

            this.PriceCommissionLocal = commission.ComputeCommissionAmount(GrossAvgPriceLocal, 1);
            this.PriceCommissionBase = PriceCommissionLocal * LocalToBaseFxRate;
            this.PriceCommissionSettle = PriceCommissionLocal * LocalToSettleFxRate;

            //Net prices must be computed according to tradeside as commission are returned in abs value and commission must be substracted from short trads
            this.NetAvgPriceLocal =GrossAvgPriceLocal + (Math.Sign(Quantity)*PriceCommissionLocal);
            this.NetAvgPriceBase = GrossAvgPriceBase + (Math.Sign(Quantity) * PriceCommissionBase);
            this.NetAvgPriceSettle = GrossAvgPriceSettle + (Math.Sign(Quantity) * PriceCommissionSettle);

            this.GrossTradeValueLocal = GrossAvgPriceLocal * Quantity;
            this.GrossTradeValueBase = GrossTradeValueLocal * LocalToBaseFxRate;
            this.GrossTradeValueSettle = GrossTradeValueLocal * LocalToSettleFxRate;


            this.GrossPrincipalLocal = GrossAvgPriceLocal * NominalQuantity;
            this.GrossPrincipalBase = GrossPrincipalLocal * LocalToBaseFxRate;
            this.GrossPrincipalSettle = GrossPrincipalLocal * LocalToSettleFxRate;

            this.CommissionAmountLocal = commission.ComputeCommissionAmount(GrossPrincipalLocal, Quantity);

            this.CommissionAmountBase = CommissionAmountLocal * LocalToBaseFxRate;

            this.CommissionAmountSettle = CommissionAmountLocal * LocalToSettleFxRate;

            this.NetTradeValueLocal = GrossTradeValueLocal + CommissionAmountLocal;
            this.NetTradeValueBase = GrossTradeValueBase + CommissionAmountBase;
            this.NetTradeValueSettle = GrossTradeValueSettle + CommissionAmountSettle;


            this.NetPrincipalLocal = GrossPrincipalLocal + CommissionAmountLocal;
            this.NetPrincipalBase = GrossPrincipalBase + CommissionAmountBase;
            this.NetPrincipalSettle = GrossPrincipalSettle + CommissionAmountSettle;


            this.ClearingBroker = clearingBroker;
            this.PrimeBroker = primeBroker;
            this.Custodian = custodian;
            this.ContractMultiplier = contractMutliplier;
            this.TradeCurrency = GrossAvgPriceLocal.Currency;
            this.ClearingAccount = clearingAccount;

            //for now we don't have this info but could be used later as often aske in the trade files
            this.MiscFeesAmountBase = new Money(0, PortfolioCurrency);
            this.MiscFeesAmountLocal = new Money(0, TradeCurrency);
            this.MiscFeesAmountSettle = new Money(0, SettlementCurrency);
        }


        public EnrichedTradeAllocation(
            int tradeAllocationId,
            int tradeId,
            Portfolio portfolio,
            PositionSide positionSide,
            Quantity quantity,
            Quantity orderAllocationQuantity,
            Money avgPriceLocal,
            decimal contractMutliplier,
            Commission commission,
            FxRate localToBaseFxRate,
            FxRate localToSettleFxRate,
            TradeSettlement tradeSettlement,
            CounterpartyRoleSetup counterparties,
            Account clearingAccount
            ) : this(tradeAllocationId, tradeId,
         portfolio.Id,
         portfolio.Currency,
         positionSide,
         quantity,
         orderAllocationQuantity,
         avgPriceLocal.Amount,
         contractMutliplier,
         commission,
         avgPriceLocal.Currency,
         localToBaseFxRate.Value,
         localToSettleFxRate.Value,
         tradeSettlement,
         counterparties.ClearingBroker.Code,
         counterparties.PrimeBroker?.Code,
         counterparties.Custodian?.Code,
         clearingAccount)
        {

        }

        public override bool Equals(object? obj)
        {
            return obj is EnrichedTradeAllocation allocation &&
                   TradeAllocationId == allocation.TradeAllocationId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TradeAllocationId);
        }

        public override string? ToString()
        {
            return $"{TradeId} {PortfolioId} {Quantity}";
        }
    }
}
