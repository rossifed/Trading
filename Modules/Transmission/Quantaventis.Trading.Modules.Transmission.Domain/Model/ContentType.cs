using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class ContentType
    {

        internal string Mnemonic { get; }
        internal ContentType(string name)
        {
            Mnemonic = name;
        }

        public override bool Equals(object? obj)
        {
            return obj is ContentType contentType &&
                   Mnemonic == contentType.Mnemonic;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Mnemonic);
        }

        public override string? ToString()
        {
            return Mnemonic;
        }
    }

}
