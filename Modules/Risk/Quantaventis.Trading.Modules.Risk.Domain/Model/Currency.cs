using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model
{
    internal class Currency
    {
        internal string Code { get; }

        internal Currency(string code)
        {
            this.Code = code;
        }

        public override bool Equals(object? obj)
         => obj is Currency country &&
                   Code == country.Code;


        public override int GetHashCode()
         => HashCode.Combine(Code);

        public override string? ToString()
         => Code;
    }
}
