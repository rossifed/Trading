using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class HandlingInstruction
    {
        internal int Id { get; }
        internal string Code { get; }

        internal string? Description { get; }

        internal HandlingInstruction(int id, string code, string? description)
        {
            Id = id;
            Code = code;
            Description = description;
        }

        public override string? ToString()
        {
            return Code;
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
