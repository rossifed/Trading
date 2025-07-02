using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class Portfolio
    {
        internal byte Id { get; }
        internal string Mnemonic { get; }

        internal Portfolio(byte id, string mnemonic) { 
        this.Id = id;
            this.Mnemonic= mnemonic;
        }
 




        public override string? ToString()
         => Mnemonic.ToString();

        public override bool Equals(object? obj)
        {
            return obj is Portfolio id &&
                   Id == id.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
