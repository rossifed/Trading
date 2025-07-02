using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Api.Dto
{
    public class GenericFutureDto :InstrumentDto
    {

        public string RootSymbol { get; set; }
      
        public decimal ContractSize { get; set; }

        public decimal TickSize { get; set; }

        public decimal TickValue { get; set; }

        public decimal PointValue { get; set; }

    }
}
