using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Api.Dto
{
    public class GenericFutureDto :InstrumentDto
    {

        public string RootSymbol { get; set; }
      
        public double ContractSize { get; set; }

        public double TickSize { get; set; }

        public double TickValue { get; set; }

        public double PointValue { get; set; }

    }
}
