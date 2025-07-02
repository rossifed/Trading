using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model
{
    internal class TargetWeight
    {
        internal TargetWeight(Instrument instrument, double weight)
        {
            this.Instrument = instrument;
            this.Weight = weight;
        }

        internal Instrument Instrument { get; }
        internal double Weight { get; }
      



     
    }
}
