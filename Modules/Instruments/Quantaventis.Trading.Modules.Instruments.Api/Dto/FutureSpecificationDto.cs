using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Api.Dto
{
    public class FutureSpecificationDto 
    {
        public int Id { get; set; }
        public string RootSymbol { get; set; }
        public string MarketSector { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }

        public double ContractSize { get; set; }

        public double TickSize { get; set; }

        public double TickValue { get; set; }

        public double PointValue { get; set; }
    }
}
