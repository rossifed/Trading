using Quantaventis.Trading.Modules.Valuation.Domain.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Api.Dto
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
