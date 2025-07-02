using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Dto
{
    public class BlockOrderDto
    {
        public int BlockOrderId { get; set; }
        public int InstrumentId { get; set; }
        public string Symbol { get; set; }
        public DateOnly TradeDate { get; set; }
        public IEnumerable<OrderAllocationDto> OrderAllocations { get; set; } = new List<OrderAllocationDto>();
        public ExecutionInfoDto ExecutionInfo { get; set; }
        public int Quantity { get; set; }

        public int BrokerId { get; set; }


    }
}
