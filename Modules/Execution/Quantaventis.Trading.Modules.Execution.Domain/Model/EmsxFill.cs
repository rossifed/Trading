namespace Quantaventis.Trading.Modules.Execution.Domain.Model
{
    internal class EmsxFill
    {

        internal EmsxFill(int orderId,
            int fillId,
            string side,
            int amount,
            int fillShares,
            decimal fillPrice,
            string currency,
            string exchange,
            string ticker,
            string yellowKey,
            bool isCfd)
        {

            this.OrderId = orderId;
            this.FillId = fillId;
            this.Side = side;
            this.Amount = amount;
            this.FillShares = fillShares;
            this.FillPrice = fillPrice;
            this.Currency = currency;
            this.Exchange = exchange;
            this.Ticker = ticker;
            this.YellowKey = yellowKey;
            this.IsCFD = isCfd;

        }
        internal string? Account { get; set; }
        internal int Amount { get; }
        internal string? AssetClass { get; set; }
        internal int? BasketId { get; set; }
        internal string? BbgId { get; set; }
        internal string? BlockId { get; set; }
        internal string? Broker { get; set; }
        internal string? ClearingAccount { get; set; }
        internal string? ClearingFirm { get; set; }
        internal DateOnly? ContractExpDate { get; set; }
        internal int? CorrectedFillId { get; set; }
        internal string Currency { get; }
        internal string? Cusip { get; set; }
        internal DateTime DateTimeOfFillUtc { get; set; }
        internal string Exchange { get; }
        internal int? ExecPrevSeqNo { get; set; }
        internal string? ExecType { get; set; }
        internal string? ExecutingBroker { get; set; }
        internal int FillId { get; }
        internal decimal FillPrice { get; }
        internal int FillShares { get; }
        internal string? InvestorId { get; set; }
        internal bool IsCFD { get; }
        internal string? Isin { get; set; }
        internal bool? IsLeg { get; set; }
        internal string? LastCapacity { get; set; }
        internal string? LastMarket { get; set; }
        internal decimal? LimitPrice { get; set; }
        internal string? Liquidity { get; set; }
        internal string? LocalExchangeSymbol { get; set; }
        internal string? LocateBroker { get; set; }
        internal string? LocateId { get; set; }
        internal bool? LocateRequired { get; set; }
        internal string? MultiLegId { get; set; }
        internal string? OccSymbol { get; set; }
        internal string? OrderExecutionInstruction { get; set; }
        internal string? OrderHandlingInstruction { get; set; }
        internal int OrderId { get; }
        internal string? OrderInstruction { get; set; }
        internal string? OrderOrigin { get; set; }
        internal string? OrderReferenceId { get; set; }
        internal int? OriginatingTraderUUId { get; set; }
        internal string? ReroutedBroker { get; set; }
        internal decimal? RouteCommissionAmount { get; set; }
        internal decimal? RouteCommissionRate { get; set; }
        internal string? RouteExecutionInstruction { get; set; }
        internal string? RouteHandlingInstruction { get; set; }
        internal int? RouteId { get; set; }
        internal decimal? RouteNetMoney { get; set; }
        internal string? RouteNotes { get; set; }
        internal int? RouteShares { get; set; }
        internal string? SecurityName { get; set; }
        internal string? Sedol { get; set; }
        internal DateOnly? SettlementDate { get; set; }
        internal string Side { get; }
        internal decimal? StopPrice { get; set; }
        internal string? StrategyType { get; set; }
        internal string Ticker { get; }
        internal string? Tif { get; set; }
        internal string? TraderName { get; set; }
        internal int? TraderUUId { get; set; }
        internal string? OrderType { get; set; }
        internal decimal? UserCommissionAmount { get; set; }
        internal decimal? UserCommissionRate { get; set; }
        internal decimal? UserFees { get; set; }
        internal decimal? UserNetMoney { get; set; }
        internal string YellowKey { get; }
        internal bool IsDFD => ExecType == "DFD";
        public override bool Equals(object? obj)
        {
            return obj is EmsxFill fill &&
                   FillId == fill.FillId &&
                   OrderId == fill.OrderId;
        }

        public override string? ToString()
        {
            return $"{Side} {FillShares} {Ticker} FillId:{FillId} OrderId:{OrderId}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FillId, OrderId);
        }
    }
}
