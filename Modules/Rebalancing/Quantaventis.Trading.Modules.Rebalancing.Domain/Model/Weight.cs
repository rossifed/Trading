using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal struct Weight
    {
        private decimal Value { get; }
        internal Weight(decimal value)
        {
            this.Value = value;
        }


        public static implicit operator Weight(decimal value) => new(value);

        public static implicit operator decimal(Weight quantity) => quantity.Value;

        public override bool Equals(object? obj)
        {
            return obj is Weight weight &&
                   Value == weight.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string? ToString()
        {
            return Value.ToString();
        }
    }
}
