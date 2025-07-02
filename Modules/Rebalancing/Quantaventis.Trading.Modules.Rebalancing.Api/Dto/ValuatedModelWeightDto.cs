using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Dto
{
    internal class ValuatedModelWeightDto
    {
        public int SecurityId { get; set; }

        public int Quantity { get; set; }

        public double Weight { get; set; }

        public double PriceInLocalCcy { get; set; }

        public double FxRate { get; set; }

        public double PriceInValuationCurrency { get; set; }
    }
}
