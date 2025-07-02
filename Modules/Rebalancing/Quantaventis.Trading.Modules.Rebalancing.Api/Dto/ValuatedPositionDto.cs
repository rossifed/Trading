
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Dto
{
    internal class ValuatedPositionDto
    {
       public int SecurityId { get; set; }

        public int Quantity { get; set; }

        public double Weight { get; set; }

        public double PriceInLocalCcy { get; set; }

        public double PriceInValuationCurrency { get; set; }

        public double GrossExposureInValuationCcy { get; set; }
        public double GrossExposureInLocalCcy { get; set; }
        public string LocalCurrency { get; set; }
        public string ValuationCurrency { get; set; }
        public double NetExposureInLocalCcy { get; set; }
        public double NetExposureInValuationCcy { get; set; }
        public double GrossExposurePercentage { get; set; }

        public double NetExposurePercentage { get; set; }
    }
}
