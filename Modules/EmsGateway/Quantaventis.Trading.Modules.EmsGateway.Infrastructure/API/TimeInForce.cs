using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class TimeInForce
    {
        private string Code { get; }
        public TimeInForce(string code)
        {
            this.Code = code;
        }


        public static implicit operator TimeInForce(string code) => new(code);

        public static implicit operator string(TimeInForce timeInForce) => timeInForce.Code;



        public override string? ToString()
         => Code;

        public override bool Equals(object? obj)
        {
            return obj is TimeInForce type &&
                   Code == type.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }
    }
}
