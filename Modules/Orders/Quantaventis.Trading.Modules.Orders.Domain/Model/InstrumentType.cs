using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class InstrumentType
    {
        internal byte Id { get; }
        internal string Mnemonic { get; }
        internal InstrumentType(byte id, string mnemonic)
        {
            Id = id;
            Mnemonic = mnemonic;
        }

        public override string? ToString()
        {
            return Mnemonic;
        }

        public override bool Equals(object? obj)
        {
            return obj is InstrumentType type &&
                   Id == type.Id;
        }
        internal bool IsFuture
            => Mnemonic == "FUT";

        internal bool IsCfd
         => Mnemonic == "CFD";
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
