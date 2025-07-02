using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model
{
    internal class InstrumentType
    {
        internal string Mnemonic { get; }


        internal InstrumentType(string Mnemonic)
        {
            this.Mnemonic = Mnemonic;
     
        }




        public override string? ToString()
         => Mnemonic;

        public override bool Equals(object? obj)
        {
            return obj is InstrumentType type &&
                   Mnemonic == type.Mnemonic;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Mnemonic);
        }
    }
}
