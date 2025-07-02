using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Api.Dto
{
    public class ExchangeDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }

        public string Name { get; set; }

        public CurrencyDto Currency { get; set; }
       
    }
}
