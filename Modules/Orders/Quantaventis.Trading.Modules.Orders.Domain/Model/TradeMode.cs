using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class TradeMode
    {
        internal byte Id { get; }
        internal string Mnemonic { get; }



        internal TradeMode(byte id, string mnemonic)
        {
            Id = id;
            Mnemonic = mnemonic;

        }
        internal bool TradeAsCFD => CFD.Equals(this);
        internal bool TradeAsEfrp => EFRP.Equals(this);
        internal static TradeMode STANDARD
            => new TradeMode(1, "STANDARD");
        internal static TradeMode EFRP
            => new TradeMode(2, "EFRP");
        internal static TradeMode CFD
            => new TradeMode(3, "CFD");
        public override bool Equals(object? obj)
        {
            return obj is TradeMode mode &&
                   Id == mode.Id;
        }
        public override string? ToString()
        {
            return Mnemonic;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
