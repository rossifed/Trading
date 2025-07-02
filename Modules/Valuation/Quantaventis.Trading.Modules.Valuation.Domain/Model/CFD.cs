using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class CFD : Instrument
    {
        internal CFD(InstrumentId id) 
            : base(id)
        {
        }

        internal override Money Valuate(Money price)
         => price;

    }
}
