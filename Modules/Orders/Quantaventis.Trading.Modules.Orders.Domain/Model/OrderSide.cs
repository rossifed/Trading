using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal struct OrderSide
    {
        internal byte Id;
        internal string Mnemonic { get; }
        private OrderSide(byte id, string mnemonic)
        {
            this.Id= id;
            this.Mnemonic = mnemonic;
        }
        internal static readonly OrderSide Buy = new OrderSide(1, "B");

        internal static readonly OrderSide Sell = new OrderSide(2,"S");

        internal static OrderSide FromMnemonic(string mnemonic) {
            IEnumerable<OrderSide> orderSides = new List<OrderSide>() { Buy, Sell};
            OrderSide? foundSide = orderSides.FirstOrDefault(o => o.Mnemonic==mnemonic.Trim().ToUpper());
            if (foundSide == null)
            throw new InvalidOperationException($"Order Side can't be crated from mnemmonic {mnemonic}");
            return foundSide.Value;
        }
        
            internal static OrderSide Create(int orderQuantity) {
            if (orderQuantity > 0 )
                return Buy;
     
            if (orderQuantity < 0 )
                return Sell;
          
            throw new InvalidOperationException($"OrderSide can't be created from order quantity:{orderQuantity}");
        }
        
    

        public override bool Equals(object? obj)
        {
            return obj is OrderSide side &&
                   Id == side.Id;
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
