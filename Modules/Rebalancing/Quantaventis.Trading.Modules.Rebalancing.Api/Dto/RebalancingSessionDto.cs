using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Dto
{
    public class RebalancingSessionDto
    {
        public int RebalancingSessionId { get; set; }

        public DateTime StartedOn { get; set; }

        public DateOnly TradeDate { get; set; }
        public IEnumerable<RebalancingOrderDto> Orders { get; set; }
        public IEnumerable<PortfolioDriftDto> PortfolioDrifts { get; set; }
    }
}
