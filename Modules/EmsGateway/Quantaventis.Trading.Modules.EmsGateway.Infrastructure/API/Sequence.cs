using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public struct Sequence
    {
        private int Value { get; }
        public Sequence(int value)
        {
            this.Value = value;
        }


        public static implicit operator Sequence(int value) => new(value);

        public static implicit operator int(Sequence sequence) => sequence.Value;

        public override bool Equals(object? obj)
        {
            return obj is Sequence id &&
                   Value == id.Value;
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
