using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Dto
{
    public class TargetWeightConversionDto
    {

        public int FromInstrumentId { get;set; }

        public double FromWeight { get; set; }


        public int ToInstrumentId { get; set; }

        public double ToWeight { get; set; }

    }
}
