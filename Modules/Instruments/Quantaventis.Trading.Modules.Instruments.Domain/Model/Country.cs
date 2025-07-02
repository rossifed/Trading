using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class Country
    {
      

        internal  int Id { get; }

        internal string Code { get; }

        public Country(int id, string code)
        {
            Id = id;
            Code = code;
        }

        public override bool Equals(object? obj)
        {
            return obj is Country country &&
                   Id == country.Id;
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
