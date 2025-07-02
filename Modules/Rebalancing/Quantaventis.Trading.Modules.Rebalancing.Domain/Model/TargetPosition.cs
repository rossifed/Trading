using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal  class TargetPosition
    {
        internal Instrument Instrument;
        internal Quantity Quantity { get; }
        internal Weight Weight { get; }

        internal TargetPosition(Instrument instrument, Quantity quantity, Weight weight)
        {
            Instrument = instrument;
            Quantity = quantity;
            Weight = weight;
        }

        internal static TargetPosition Flat(Instrument instrument)
                => new TargetPosition(instrument, 0, 0);


        public override string? ToString()
        {
            return $"{Instrument} {Quantity}, {Weight}";
        }

        public override bool Equals(object? obj)
        {
            return obj is TargetPosition position &&
                   EqualityComparer<Instrument>.Default.Equals(Instrument, position.Instrument);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Instrument);
        }
    }
}
