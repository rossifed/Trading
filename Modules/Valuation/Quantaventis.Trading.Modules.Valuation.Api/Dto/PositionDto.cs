using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Api.Dto
{
    public class PositionDto
    {
        public byte PortfolioId { get; set; }

        public int InstrumentId { get; set; }

        public int? Quantity { get; set; }

        public decimal AvgTradePriceLocal { get; set; }

        public decimal GrossTotalCostLocal { get; set; }

        public decimal NetTotalCostLocal { get; set; }

        public DateOnly PositionDate { get; set; }

        public string TradeCurrency { get; set; } = null!;

    }
}
