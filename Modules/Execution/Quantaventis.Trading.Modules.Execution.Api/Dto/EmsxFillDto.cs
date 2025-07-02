

namespace Quantaventis.Trading.Modules.Execution.Api.Dto
{
    public class EmsxFillDto
    {
        public string? Account { get; set; }
        public double Amount { get; set; }
        public string? AssetClass { get; set; }
        public int? BasketId { get; set; }
        public string? Bbgid { get; set; }
        public string? BlockId { get; set; }
        public string? Broker { get; set; }
        public string? ClearingAccount { get; set; }
        public string? ClearingFirm { get; set; }
        public DateTime ContractExpDate { get; set; }
        public int? CorrectedFillId { get; set; }
        public string? Currency { get; set; }
        public string? Cusip { get; set; }
        public DateTime DateTimeOfFillUtc { get; set; }
        public string? Exchange { get; set; }
        public int? ExecPrevSeqNo { get; set; }
        public string? ExecType { get; set; }
        public string? ExecutingBroker { get; set; }
        public int FillId { get; set; }
        public double FillPrice { get; set; }
        public double FillShares { get; set; }
        public string? InvestorId { get; set; }
        public bool IsCFD { get; set; }
        public string? Isin { get; set; }
        public bool IsLeg { get; set; }
        public string? LastCapacity { get; set; }
        public string? LastMarket { get; set; }
        public double? LimitPrice { get; set; }
        public string? Liquidity { get; set; }
        public string? LocalExchangeSymbol { get; set; }
        public string? LocateBroker { get; set; }
        public string? LocateId { get; set; }
        public bool LocateRequired { get; set; }
        public string? MultiLegId { get; set; }
        public string? OccSymbol { get; set; }
        public string? OrderExecutionInstruction { get; set; }
        public string? OrderHandlingInstruction { get; set; }
        public int OrderId { get; set; }
        public string? OrderInstruction { get; set; }
        public string? OrderOrigin { get; set; }
        public string? OrderReferenceId { get; set; }
        public int? OriginatingTraderUUId { get; set; }
        public string? ReroutedBroker { get; set; }
        public double RouteCommissionAmount { get; set; }
        public double RouteCommissionRate { get; set; }
        public string? RouteExecutionInstruction { get; set; }
        public string? RouteHandlingInstruction { get; set; }
        public int RouteId { get; set; }
        public double RouteNetMoney { get; set; }
        public string? RouteNotes { get; set; }
        public double RouteShares { get; set; }
        public string? SecurityName { get; set; }
        public string? Sedol { get; set; }
        public DateTime? SettlementDate { get; set; }
        public string? Side { get; set; }
        public double? StopPrice { get; set; }
        public string? StrategyType { get; set; }
        public string? Ticker { get; set; }
        public string? Tif { get; set; }
        public string? TraderName { get; set; }
        public int TraderUUId { get; set; }
        public string? Type { get; set; }
        public double UserCommissionAmount { get; set; }
        public double UserCommissionRate { get; set; }
        public double UserFees { get; set; }
        public double UserNetMoney { get; set; }
        public string? YellowKey { get; set; }

    }
}
