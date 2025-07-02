using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dto
{
    internal class CurrencyPairDto
    {

        public string Symbol { get; set; }

        public string BaseCurrency { get; set; }

        public string QuoteCurrency { get; set; }
    }
}
