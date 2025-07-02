using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dto
{
    public class FutureSpecificationDto
    {


        public string RootSymbol { get; }

        public string Name { get; }

        public string MarketSector { get; }

        public string Currency { get; }

        public double ContractSize { get; }
        public double TickSize { get; }
        public double TickValue { get; }

        public double PointValue { get; }
    }
}
