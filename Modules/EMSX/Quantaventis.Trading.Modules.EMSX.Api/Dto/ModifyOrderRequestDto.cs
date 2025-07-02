namespace Quantaventis.Trading.Modules.EMSX.Api.Dto
{
    public class ModifyOrderRequestDto
    {
        public int Sequence { get; set;}
        public int Amount { get; set;}
        public string OrderType { get; set;}
        public double? LimitPrice { get; set;}

        public string? TimeInForce { get; set;}

        public string? HandInstruction { get; set;}
        public string? Account { get; set;}
        public string? CfdFlag { get; set;}

        public string? ExecInstruction { get; set;}
        public DateTime? GtdDate { get; set;}
        public string? InvestorId { get; set;}
        public string? Notes { get; set;}
        public string? Warnings { get; set;}
        public int? RequestSequence { get; set;}

        public double? StopPrice { get; set;}
        public int? TraderUuid { get; set;}
    }
}
