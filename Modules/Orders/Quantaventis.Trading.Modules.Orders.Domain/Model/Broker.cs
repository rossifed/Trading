using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class Broker
    {

        internal int Id { get; }
        internal string Code { get; }
        internal Broker(int id, string code)
        {
            Id = id;
            Code = code;

        }

        public override string? ToString()
        {
            return Code;
        }

        public override bool Equals(object? obj)
        {
            return obj is Broker broker &&
                   Id == broker.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
