using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Api.Dto
{
    public class InstrumentDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }

       public string InstrumentType { get; set; }
    }
}
