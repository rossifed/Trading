using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class Counterparty
    {

        internal string Name { get; }
        internal Counterparty(string name)
        {
            Name = name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Counterparty counterparty &&
                   Name == counterparty.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override string? ToString()
        {
            return Name;
        }
    }

}
