using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class Counterparty
    {
        internal int Id { get; }
        internal string Code { get; }
        internal string Name { get; }

        public Counterparty(int counterpartyId, string code, string name)
        {
            Id = counterpartyId;
            Code = code;
            Name = name;
        }

        public override string? ToString()
        {
            return Code;
        }

        public override bool Equals(object? obj)
        {
            return obj is Counterparty counterparty &&
                   Id == counterparty.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
