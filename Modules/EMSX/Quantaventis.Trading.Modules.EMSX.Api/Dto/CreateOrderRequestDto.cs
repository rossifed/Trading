namespace Quantaventis.Trading.Modules.EMSX.Api.Dto
{
    public class CreateOrderRequestDto
    {

        public string Ticker { get;  set; }
        public int Amount { get;  set; }
        public string OrderType { get;  set; }
        public string TimeInForce { get;  set; }
        public string HandInstruction { get;  set; }
        public string Side { get;  set; }
        public string? Account { get; set; }
        public string? BasketName { get; set; }
        public string? Broker { get; set; }
        public string? CfdFlag { get; set; }
        public string? ClearingAccount { get; set; }
        public string? ClearingFirm { get; set; }
        public string? CustomNote1 { get; set; }
        public string? CustomNote2 { get; set; }
        public string? CustomNote3 { get; set; }
        public string? CustomNote4 { get; set; }
        public string? CustomNote5 { get; set; }
        public string? ExchangeDestination { get; set; }
        public string? ExecInstruction { get; set; }
        public string? Warnings { get; set; }
        public DateTime? GtdDate { get; set; }
        public string? InvestorId { get; set; }
        public double? LimitPrice { get; set; }
        public string? LocateId { get; set; }
        public string? LocateRequest { get; set; }
        public string? Notes { get; set; }
        public double? OddLot { get; set; }
        public string? OrderOrigin { get; set; }
        public string? OrderRefId { get; set; }
        public double? Pa { get; set; }
        public TimeSpan? ReleaseTime { get; set; }
        public int? RequestSequence { get; set; }
        public string? SettlementCurrency { get; set; }
        public DateTime? SettlementDate { get; set; }
        public string? SettlementType { get; set; }
        public double? StopPrice { get; set; }
        public string? LocateBroker { get; set; }

    }
}
