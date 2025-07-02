using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Portfolios.Domain.Model
{
    internal class Instrument
    {
       internal int Id { get; }

        internal Instrument(int id) { 
        this.Id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Instrument instrument &&
                   Id == instrument.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
