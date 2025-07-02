using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class ExecutionAlgorithm
    {

        internal int Id { get; }
        internal string Mnemonic { get; }

        internal string Name { get; }

        internal ExecutionAlgorithm(int id, string mnemonic, string name)
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
            return obj is ExecutionAlgorithm algorithm &&
                   Id == algorithm.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
