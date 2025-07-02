using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Dto
{
    public class RebalancingOrderDto
    {
        public int RebalancingSessionId { get; set; }
        public int InstrumentId { get; set; }
        public int Quantity { get; set; }
        public byte PortfolioId { get; set; }
        public DateOnly TradeDate { get; set; }
        public int CurrentPositionQuantity { get; set; }
        public int TargetPositionQuantity { get; set; }
        
    }
}
