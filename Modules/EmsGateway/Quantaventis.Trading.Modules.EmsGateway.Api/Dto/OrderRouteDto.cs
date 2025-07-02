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
    public class OrderRouteDto
    {
    
        public int OrderId { get; set; }
      
        public int Quantity { get; set; }
   
        public string TradingDesk { get; set; }

        public string BrokerCode { get; set; }

        public string TradeMode { get; set; }

        public IEnumerable<ExecutionAlgoParamDto> ExecutionAlgoParams { get; set; }
        public string ExecutionAlgorithm { get; set; }
        public string OrderType { get; set; }
        public string TimeInForce { get; set; }
        public string HandlingInstruction { get; set; }
        public string ExecutionChannel { get; set; }
    }
}
