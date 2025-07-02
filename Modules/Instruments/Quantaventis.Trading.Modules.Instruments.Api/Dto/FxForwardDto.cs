using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Api.Dto
{
    public class FxForwardDto :InstrumentDto
    {

        public CurrencyPairDto CurrencyPair { get; set; }
        public string BaseCurrency { get; set; }

        public string QuoteCurrency { get; set; }

        public DateOnly MaturityDate { get; set; }

    }
}
