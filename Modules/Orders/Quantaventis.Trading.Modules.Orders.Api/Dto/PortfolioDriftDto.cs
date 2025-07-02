using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.Dto
{
    public class PortfolioDriftDto
    {
        public int PortfolioDriftId { get; set; }
        public byte PortfolioId { get; set; }
        public int TargetAllocationId { get; set; }

        public int TargetAllocationValuationId { get; set; }
        public int PortfolioValuationId { get; set; }
        public IEnumerable<PositionDriftDto> PositionDrifts { get; set; }

        
    }
}
