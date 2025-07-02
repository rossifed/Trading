using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal class Instrument
    {
        internal InstrumentId Id { get; }
        internal string Symbol { get; }

        internal string InstrumentType { get; }
        internal Instrument(InstrumentId id, string symbol, string instrumentType) { 
        this.Symbol = symbol;
            this.Id = id;
            this.InstrumentType= instrumentType;
  
        }
 


        public override bool Equals(object? obj)
        {
            return obj is Instrument symbol &&
                   Symbol == symbol.Symbol;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Symbol);
        }

        public override string? ToString()
         => Symbol;
    }
}
