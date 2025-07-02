using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.Dto
{
    public class InstrumentDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Currency { get; set; }
        public string Name { get; set; }
        public int CurrencyId { get; set; }
        public string? Exchange { get; set; }

        public string InstrumentType { get; set; }
        public byte InstrumentTypeId { get; set; }
        public string MarketSector { get; set; }

       

    }
}
