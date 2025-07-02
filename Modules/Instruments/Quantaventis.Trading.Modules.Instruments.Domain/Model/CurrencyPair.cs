using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class CurrencyPair
    {
        internal Instrument Instrument { get; }
        internal int Id { get; }

        internal Currency BaseCurrency { get; }

        internal Currency QuoteCurrency { get; }

        internal string Symbol => Instrument.Symbol;

        internal CurrencyPair(Instrument instrument, Currency baseCurrency, Currency quoteCurrency)
        { 
            this.Id = instrument.Id;
            this.Instrument = instrument;
            this.BaseCurrency = baseCurrency;
            this.QuoteCurrency = quoteCurrency;
        }
        internal CurrencyPair WithId(int id)
            => new CurrencyPair(Instrument.WithId(id), BaseCurrency, QuoteCurrency);


        public override bool Equals(object? obj)
        {
            return obj is CurrencyPair CurrencyPair &&
                   Id == CurrencyPair.Id;
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
