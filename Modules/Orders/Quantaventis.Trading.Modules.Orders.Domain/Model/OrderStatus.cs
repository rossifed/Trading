using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal struct OrderStatus
    {
        internal int Id;
        internal string Mnemonic { get; }
        private OrderStatus(int id, string mnemonic)
        {
            this.Mnemonic = mnemonic;
        }
        internal static readonly OrderStatus New = new OrderStatus(1, "NEW");
        internal static readonly OrderStatus Uploaded = new OrderStatus(2, "UPLOADED");
        internal static readonly OrderStatus Routed = new OrderStatus(3, "ROUTED");

        internal static readonly OrderStatus Cancelled = new OrderStatus(4, "CANCELLED");
        internal static readonly OrderStatus PartFilled = new OrderStatus(5, "PARTFILLED");
        internal static readonly OrderStatus Filled = new OrderStatus(6, "FILLED");
   
        public override bool Equals(object? obj)
        {
            return obj is OrderSide side &&
                   Mnemonic == side.Mnemonic;
        }
        public override string? ToString()
        {
            return Mnemonic;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Mnemonic);
        }
    }
}
