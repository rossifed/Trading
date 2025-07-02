using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Api.Dto
{
    public class TradeAllocationDto
    {
      

        public int TradeId { get; set; }

        public byte PortfolioId { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int OrderAllocationQuantity { get; set; }
        public string PriceCurrency { get; set; }

    }
}
