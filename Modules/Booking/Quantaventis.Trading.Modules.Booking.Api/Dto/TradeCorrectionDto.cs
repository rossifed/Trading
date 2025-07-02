using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Api.Dto
{
    public class TradeCorrectionDto
    {


        public decimal? AvgPriceLocal { get; set; }
        public string? TradeInstrumentType { get; set; }
        public decimal? ContractMultiplier { get; set; }
        public bool? IsSwap { get; set; }
        public string? ExecutionBroker { get; set; }
        public string? ExecutionAccount { get; set; }
        public string? Exchange { get; set; }
        public string? ExecutionType { get; set; }
        public DateOnly? TradeDate { get; set; }
    }
}
