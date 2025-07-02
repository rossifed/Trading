using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model
{
    internal class Industry
    {
        internal string Code { get; }
        internal string Name { get; }

        internal Industry(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }

        public override bool Equals(object? obj)
            => obj is Industry industry &&
                   Code == industry.Code;

        public override int GetHashCode()
         => HashCode.Combine(Code);

        public override string? ToString()
         => Name;
    }
}
