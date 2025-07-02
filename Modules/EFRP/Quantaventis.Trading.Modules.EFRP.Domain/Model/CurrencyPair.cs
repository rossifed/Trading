using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class CurrencyPair
    {

      internal  Currency BaseCurrency { get; }

        internal Currency QuoteCurrency { get; }

        public CurrencyPair(Currency baseCurrency, Currency quoteCurrency)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
        }

        public override string? ToString()
        {
            return $"{BaseCurrency}{QuoteCurrency}";
        }

        public override bool Equals(object? obj)
        {
            return obj is CurrencyPair pair &&
                   BaseCurrency == pair.BaseCurrency &&
                   QuoteCurrency == pair.QuoteCurrency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BaseCurrency, QuoteCurrency);
        }
    }
}
