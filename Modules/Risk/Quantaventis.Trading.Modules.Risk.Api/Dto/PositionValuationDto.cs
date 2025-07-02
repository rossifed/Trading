namespace Quantaventis.Trading.Modules.Risk.Api.Dto
{
    public class PositionValuationDto
    {
        public int InstrumentId { get; set; }

        public int Quantity { get; set; }

        public decimal Weight { get; set; }

        public decimal PriceInLocalCcy { get; set; }

        public decimal InstrumentValue { get; set; }
        public decimal NetExposure { get; set; }

        public decimal GrossExposure { get; set; }
        public decimal FxRate { get; set; }

        public decimal ROI { get; set; }
        public decimal UnrealizedPnL { get; set; }
        public decimal InstrumentPrice { get; set; }

        public string InstrumentCurrency { get; set; }

        public string ValuationCurrency { get; set; }
        public DateTime PriceDate { get; set; }

    }
}
