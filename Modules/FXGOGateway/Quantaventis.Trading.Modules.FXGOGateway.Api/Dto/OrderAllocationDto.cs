using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.Dto
{
    public class OrderAllocationDto
    {

        public int TradingAccountId { get; set; }
        public string TradingAccount { get; set; }
        public byte PortfolioId { get; set; }

        public int Quantity { get; set; }

        public string PositionSide { get; set; }

    }
}
