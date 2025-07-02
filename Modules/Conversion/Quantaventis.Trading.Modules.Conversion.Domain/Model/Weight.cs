using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal class Weight
    {
  
        private double Value { get; }
        internal Weight(double value) { 
        this.Value = value;
        }
        internal decimal ToDecimal() => (decimal)Value;
        internal Weight Invert() => new Weight(-Value);

        public static implicit operator Weight(double value) => new(value);

        public static implicit operator double(Weight weight) => weight.Value;
    }
}
