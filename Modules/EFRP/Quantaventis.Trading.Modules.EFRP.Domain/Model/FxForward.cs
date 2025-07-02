using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class FxForward
    {
        internal CurrencyPair CurrencyPair { get; }
        internal DateOnly MaturityDate { get; }
        internal Currency BaseCurrency => CurrencyPair.BaseCurrency;
        internal Currency QuoteCurrency => CurrencyPair.QuoteCurrency;
        internal string Symbol 
            => $"{BaseCurrency}/{QuoteCurrency} {MaturityDate.ToString("MM/dd/yyyy")} Curncy";

        public FxForward(CurrencyPair currencyPair, DateOnly maturityDate)
        {
            CurrencyPair = currencyPair;
            MaturityDate = maturityDate;
        }
    }
}
