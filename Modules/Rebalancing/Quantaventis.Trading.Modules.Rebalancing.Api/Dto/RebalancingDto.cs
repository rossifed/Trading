using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Dto
{
    public class RebalancingDto
    {
        public int RebalancingId { get; set; }
        public byte PortfolioId { get; set; }
        public int TargetAllocationId { get; set; }

        public int PortfolioDriftId { get; set; }

        public int TargetAllocationValuationId { get; set; }
        public int PortfolioValuationId { get; set; }
        public DateTime StartedOn { get; set; }

        public IEnumerable<PositionDriftDto> PositionDrifts { get; set; }
    }
}
