using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Api.Dto
{
    public class CurrencyPairDto :InstrumentDto
    {
 
        public string BaseCurrency { get; set; }

        public string QuoteCurrency { get; set; }

       
    }
}
