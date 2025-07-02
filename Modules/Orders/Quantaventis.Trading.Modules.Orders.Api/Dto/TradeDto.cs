using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.Dto
{
    public class TradeDto
    {
        public int Id { get; set; }

        public int InstrumentId { get; set; }
        public string Symbol { get; set; }

        public DateTime TradeDate { get; set; }

        public double Quantity { get; set; }
        public decimal TradePrice { get; set; }
        public string TradeCurrency { get; set; }
        public byte PortfolioId { get; set; }
    
    }
}
