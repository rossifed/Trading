using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal struct ExecutionChannel
    {
    
        internal byte Id { get; }
        internal string Mnemonic { get; }

        public ExecutionChannel(byte id, string mnemonic)
        {
            Id = id;
            Mnemonic = mnemonic;
        }

        public override bool Equals(object? obj)
        {
            return obj is ExecutionChannel channel &&
                   Id == channel.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
            => Mnemonic;
    }
}
