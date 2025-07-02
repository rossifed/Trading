using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal class Instrument
    {
        internal InstrumentId Id { get; }
        internal string Symbol { get; }
        internal string InstrumentType { get; }
        internal Instrument(InstrumentId id, string symbol, string instrumentType) { 
            this.Id = id;
            this.Symbol = symbol;
            this.InstrumentType = instrumentType;
        }

        public override bool Equals(object? obj)
        {
            return obj is Instrument instrument &&
                   EqualityComparer<InstrumentId>.Default.Equals(Id, instrument.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return Symbol;
        }
    }
}
