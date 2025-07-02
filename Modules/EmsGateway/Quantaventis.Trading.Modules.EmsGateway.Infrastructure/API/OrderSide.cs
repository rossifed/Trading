using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class OrderSide
    {
        private string Code { get; }
        public OrderSide(string code)
        {
            this.Code = code;
        }


        public static implicit operator OrderSide(string code) => new(code);

        public static implicit operator string(OrderSide orderSide) => orderSide.Code;



        public override string? ToString()
         => Code;

        public override bool Equals(object? obj)
        {
            return obj is OrderSide type &&
                   Code == type.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }
    }
}
