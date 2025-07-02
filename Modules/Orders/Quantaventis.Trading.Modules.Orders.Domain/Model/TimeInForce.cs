using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class TimeInForce
    {
        internal byte Id { get; }
        internal string Mnemonic { get; }



        internal TimeInForce(byte id, string mnemonic)
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
            return obj is TimeInForce tif &&
                   Id == tif.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
