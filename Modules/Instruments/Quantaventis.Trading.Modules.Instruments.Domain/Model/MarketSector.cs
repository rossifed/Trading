using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class MarketSector
    {
       internal byte Id { get; }
        internal string Mnemonic { get; }

        public MarketSector(byte id, string mnemonic)
        {
            Id = id;
            Mnemonic = mnemonic;
        }
    }
}
