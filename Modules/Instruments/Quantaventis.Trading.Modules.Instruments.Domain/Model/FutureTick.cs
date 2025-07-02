using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class FutureTick
    {

        internal double TickSize { get; }
        internal double TickValue { get; }

        internal double PointValue { get; }

        public FutureTick(double tickSize, double tickValue, double pointValue)
        {
            TickSize = tickSize;
            TickValue = tickValue;
            PointValue = pointValue;
        }

        public override bool Equals(object? obj)
        {
            return obj is FutureTick tick &&
                   TickSize == tick.TickSize &&
                   TickValue == tick.TickValue &&
                   PointValue == tick.PointValue;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TickSize, TickValue, PointValue);
        }
    }
}
