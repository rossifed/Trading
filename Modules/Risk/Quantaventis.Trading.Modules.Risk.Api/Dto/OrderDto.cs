using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Api.Dto
{
    public class OrderDto
    {
        public int RebalancingSessionId { get; set; }
        public int InstrumentId { get; set; }
        public int Quantity { get; set; }
        public byte PortfolioId { get; set; }



    }
}
