using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Dto
{
    public class OrderDto
    {
        public int? RebalancingSessionId { get; set; }
        public int OrderId { get; set; }
        public int InstrumentId { get; set; }
        public string Symbol { get; set; }

        public DateOnly? ContractMaturity { get; set; }
        public string Exchange { get; set; }
        public DateOnly TradeDate { get; set; }
        public bool IsCfd { get; set; }
        public bool IsEfrp { get; set; }
        public string InstrumentType { get; set; }
        public bool IsSingleAllocation { get; set; }
        public IEnumerable<OrderAllocationDto> OrderAllocations { get; set; } = new List<OrderAllocationDto>();

        public int Quantity { get; set; }

        public string OrderSide { get; set; }
        public int BrokerId { get; set; }

        public string TradingDesk { get; set; }

        public string BrokerCode { get; set; }

        public string TradeMode { get; set; }

        public IEnumerable<ExecutionAlgoParamDto> ExecutionAlgoParams { get; set; }
        public string ExecutionAlgorithm { get; set; }
        public string OrderType { get; set; }
        public string TimeInForce { get; set; }
        public string HandlingInstruction { get; set; }
        public string ExecutionChannel { get; set; }
        public string OrderReason { get; set; }
    }
}
