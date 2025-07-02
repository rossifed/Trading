using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class FutureContractMonth
    {
        internal byte Id { get; }
        internal string Code { get; }

        public FutureContractMonth(byte id, string code)
        {
            Id = id;
            Code = code;
        }

        public override bool Equals(object? obj)
        {
            return obj is FutureContractMonth month &&
                   Id == month.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
