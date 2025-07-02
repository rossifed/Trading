using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class Instrument
    {
        internal int Id { get; }
        internal string Symbol { get; }
        public Instrument(int id, string symbol)
        {
            Id = id;
            Symbol = symbol;
        }

        public override string? ToString()
        {
            return Symbol;
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
