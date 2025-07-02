using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Api.Dto
{
    public class ModelWeightDto
    {

        public int InstrumentId { get;set; }
        public string Symbol { get; set; }

        public double Weight { get; set; }




    }
}
