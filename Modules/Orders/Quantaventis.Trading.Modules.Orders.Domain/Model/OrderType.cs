using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class OrderType
    {
        internal int Id { get; }
        internal string Mnemonic { get; }

        internal string Name { get; }

        internal OrderType(int id, string mnemonic, string name)
        {
            Id = id;
            Mnemonic = mnemonic;
            Name = name;
        }

        public override string? ToString()
        {
            return Mnemonic;
        }

        public override bool Equals(object? obj)
        {
            return obj is OrderType orderType &&
                   Id == orderType.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
