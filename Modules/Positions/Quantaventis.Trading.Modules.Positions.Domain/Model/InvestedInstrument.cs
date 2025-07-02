using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Positions.Domain.Model
{
    internal class InvestedInstrument
    {
        internal int InstrumentId { get; }
        internal bool IsSwap { get; }

        public InvestedInstrument(int instrumentId, bool isSwap)
        {
            InstrumentId = instrumentId;
            IsSwap = isSwap;
      
        }

        public override bool Equals(object? obj)
        {
            return obj is InvestedInstrument instrument &&
                   InstrumentId == instrument.InstrumentId &&
                   IsSwap == instrument.IsSwap;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(InstrumentId, IsSwap);
        }
    }
}
