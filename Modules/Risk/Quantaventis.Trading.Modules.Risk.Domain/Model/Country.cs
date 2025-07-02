using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model
{
    internal class Country
    {
        internal string Code { get; }
        internal string Name { get; }
        internal Region Region { get; }

        internal Country(string code, string name, Region region)
        {
            this.Code = code;
            this.Name = name;
            this.Region = region;

        }

        public override bool Equals(object? obj)
       => obj is Country country &&
                   Code == country.Code;


        public override int GetHashCode()
         => HashCode.Combine(Code);


        public override string? ToString()
         => Name;
    }
}
