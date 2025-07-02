using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal struct PositionSide
    {
        internal byte Id;
        internal string Mnemonic { get; }
        private PositionSide(byte id, string mnemonic)
        {
            this.Id= id;
            this.Mnemonic = mnemonic;
        }
        internal static readonly PositionSide Long = new PositionSide(1,"L");
        internal static readonly PositionSide Short = new PositionSide(2,"S");
        internal static readonly PositionSide Close = new PositionSide(3,"C");
        internal static PositionSide FromMnemonic(string mnemonic) {
            IEnumerable<PositionSide> orderSides = new List<PositionSide>() { Long, Short, Close};
            PositionSide? foundSide = orderSides.FirstOrDefault(o => o.Mnemonic==mnemonic.Trim().ToUpper());
            if (foundSide == null)
            throw new InvalidOperationException($"Position Side can't be crated from mnemmonic {mnemonic}");
            return foundSide.Value;
        }
        
            internal static PositionSide Create(int targetPositionQuantity) {


            if (targetPositionQuantity > 0)
                return Long;
            if (targetPositionQuantity < 0)
                return Short;
            else
                return Close;
           
            
        }

        public override string? ToString()
        {
            return Mnemonic;
        }

        public override bool Equals(object? obj)
        {
            return obj is PositionSide side &&
                   Id == side.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
