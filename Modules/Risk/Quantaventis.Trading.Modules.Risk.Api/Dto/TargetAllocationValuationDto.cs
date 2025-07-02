namespace Quantaventis.Trading.Modules.Risk.Api.Dto
{
    internal class TargetAllocationValuationDto
    {
        public int TargetAllocationValuationId { get; set; }
        public int TargetAllocationId { get; set; }

        public byte PortfolioId { get; set; }
        public string ValuationCurrency { get; set; }
        public decimal TargetNetExposure { get; set; }
        public decimal TargetGrossExposure { get; set; }

        public decimal PortfolioValue { get; set; }
        public decimal TotalWeight { get; set; }

        public DateTime ValuatedOn { get; set; }
        public IEnumerable<TargetWeightValuationDto> TargetWeightValuations { get; set; }    
    }
}
