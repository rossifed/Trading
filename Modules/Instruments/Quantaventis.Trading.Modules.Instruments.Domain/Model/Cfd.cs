using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class Cfd
    {
        internal Instrument Instrument { get; }
        internal int Id { get; }

        internal Instrument Underlying { get; }
        internal string Symbol => Instrument.Symbol;
    
        internal Cfd(Instrument instrument, Instrument underlying)
        { 
            this.Id = instrument.Id;
            this.Instrument = instrument;
            this.Underlying = underlying;   
        }
        internal Cfd WithId(int id)
            => new Cfd(Instrument.WithId(id), Underlying);


        public override bool Equals(object? obj)
        {
            return obj is Cfd CurrencyPair &&
                   Symbol == CurrencyPair.Symbol;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Symbol);
        }

        public override string? ToString()
        {
            return Symbol;
        }
    }
}
