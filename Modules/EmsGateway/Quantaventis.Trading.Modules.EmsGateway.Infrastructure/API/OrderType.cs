using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class OrderType
    {
        private string Code { get; }
        public OrderType(string code)
        {
            this.Code = code;
        }
        public static OrderType Market => new OrderType("MKT");
        public static OrderType Limit => new OrderType("LMT");
        public static implicit operator OrderType(string code) => new(code);

        public static implicit operator string(OrderType orderType) => orderType.Code;



        public override string? ToString()
         => Code;

        public override bool Equals(object? obj)
        {
            return obj is OrderType type &&
                   Code == type.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }
    }
}
