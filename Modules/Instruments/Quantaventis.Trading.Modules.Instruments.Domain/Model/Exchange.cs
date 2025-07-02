using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class Exchange
    {

      internal  short Id { get; }

        internal string Code { get; }

        internal TimeZone TimeZone { get; }

        internal Country Country { get; }

        internal Currency Currency { get; }

        internal Exchange(short id, string code)
        {
            Id = id;
            Code = code;
   
        }

        public override bool Equals(object? obj)
        {
            return obj is Exchange exchange &&
                   Id == exchange.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return Code;
        }
    }
}
