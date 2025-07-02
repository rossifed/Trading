using Quantaventis.Trading.Modules.Valuation.Domain.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Api.Dto
{
    public class PortfolioValuationDto
    {
        public int PortfolioValuationId { get; set; }
        public byte PortfolioId { get; set; }

        public DateTime ValuationDate { get; set; }

        public decimal PortfolioValue { get; set; }
        public decimal NetExposure { get; set; }
        public decimal GrossExposure { get; set; }
        public decimal PnL { get; set; }
        public decimal ROI { get; set; }
        public string ValuationCurrency { get; set; }
       
        public IEnumerable<PositionValuationDto> PositionValuations { get; set; }
    }
}
