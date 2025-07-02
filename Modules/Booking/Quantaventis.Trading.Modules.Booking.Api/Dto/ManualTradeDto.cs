using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Api.Dto
{
    public class ManualTradeDto
    {
        public string? Symbol { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

        public string Exchange { get; set; }
        public string ExecutionDesk { get; set; }

        public string ExecutionAccount{ get; set; }
        public bool IsCfd { get; set; } = false;
        public DateOnly? TradeDate { get; set; }
        public byte PortfolioId { get; set; }
        public string? PositionSide { get; set; }

    }
}
