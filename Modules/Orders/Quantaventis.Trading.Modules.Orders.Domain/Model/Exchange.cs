using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class Exchange
    {
       internal int Id { get; }
        internal string Symbol { get; }



        internal Exchange(int id, string symbol)
        {
            Id = id;
            Symbol = symbol;

        }

        public override string? ToString()
        {
            return Symbol;
        }

        public override bool Equals(object? obj)
        {
            return obj is Exchange exchange &&
                   Id == exchange.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
        
    }
}
