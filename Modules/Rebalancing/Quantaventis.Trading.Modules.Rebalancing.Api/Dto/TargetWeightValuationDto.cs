using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Dto
{
    internal class TargetWeightValuationDto
    {
         
        public int InstrumentId { get; set; }
        public decimal Weight { get; set; }

        public decimal Price { get; set; }

        public DateTime PricedOn { get; set; }

        public string PriceCurrency { get; set; }
        public decimal InstrumentValue{ get; set; }
        public int TargetQuantity { get; set; }

        public decimal TargetNetExposure { get; set; }

        public decimal TargetGrossExposure { get; set; }
        public string ValuationCurrency { get; set; }

    }
}
