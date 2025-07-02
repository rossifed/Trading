using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model
{
    internal class Region
    {
        internal string Code { get; }
        internal string Name { get; }

        internal Region(string code, string Name)
        {
            this.Code = code;
            this.Name = Name;
        }

        public override string? ToString()
         => Name;

        public override bool Equals(object? obj)
         => obj is Region region &&
                   Code == region.Code;

        public override int GetHashCode()
         => HashCode.Combine(Code);
    }
}
