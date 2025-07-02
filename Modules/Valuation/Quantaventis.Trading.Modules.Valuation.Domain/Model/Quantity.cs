using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal struct Quantity
    {
        private int Value { get; }
        internal Quantity(int value)
        {
            this.Value = value;
        }


        public static implicit operator Quantity(int value) => new(value);

        public static implicit operator int(Quantity quantity) => quantity.Value;


    }
}
