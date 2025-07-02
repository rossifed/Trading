using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class InstrumentType
    {

        internal byte Id { get; }
        internal string Mnemonic { get; }

        public InstrumentType(byte id, string mnemonic)
        {
            Id = id;
            Mnemonic = mnemonic;
        }

        public override bool Equals(object? obj)
        {
            return obj is InstrumentType type &&
                   Id == type.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return Mnemonic;
        }
    }
}
