using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class TradingDesk
    {

        internal int Id { get; }
        internal string Code { get; }

        internal TradingDesk(int id, string code)
        {
            Id = id;
            Code = code;

        }

        public override string? ToString()
        {
            return Code;
        }

        public override bool Equals(object? obj)
        {
            return obj is TradingDesk tradingDesk &&
                   Id == tradingDesk.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
