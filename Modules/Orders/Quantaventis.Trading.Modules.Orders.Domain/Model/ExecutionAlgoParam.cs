using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class ExecutionAlgoParam
    {

        internal string Parameter { get; set; }

        internal string? Value { get; set; }

        public ExecutionAlgoParam(string parameter, string? value)
        {
            Parameter = parameter;
            Value = value;
        }

        public override string? ToString()
        {
            return $"{Parameter}: {Value}";
        }

        public override bool Equals(object? obj)
        {
            return obj is ExecutionAlgoParam param &&
                   Parameter == param.Parameter &&
                   Value == param.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Parameter, Value);
        }
    }
}
