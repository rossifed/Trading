using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.Dto
{
    public class ExecutionProfileDto
    {
        public IEnumerable<ExecutionAlgoParamDto> ExecutionAlgoParams { get; set; }
        public string ExecutionAlgorithm { get; set; }
        public string OrderType { get; set; }
        public string TimeInForce { get; set; }
        public string HnadlingInstruction { get; set; }
        public string ExecutionChannel { get; set; }

    }
}
