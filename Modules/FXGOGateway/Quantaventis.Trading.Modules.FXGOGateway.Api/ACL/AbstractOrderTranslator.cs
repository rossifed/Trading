using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.ACL
{
    internal class CurrencyPair { 
        string BaseCurrency { get; }
        string QuoteCurrency { get; }

        public CurrencyPair(string baseCurrency, string quoteCurrency)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
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
    internal class AbstractOrderTranslator
    {
        private static IEnumerable<string> NdfCurrencyPairs = new List<string>() {
        "KRWUSD", "BRLUSD", "IDRUSD","COPUSD","PENUSD","USDKRW", "USDBRL", "USDIDR","USDCOP","USDPEN"

        };//TODO: Bad, this should be defined at the currency level in instruments.
        private bool IsNdf(string currencyPair)
        => NdfCurrencyPairs.Contains(currencyPair);
        protected string GetOrderSide(long quantity)
                => quantity >= 0 ? "B" : "S";
        protected char GetNdfFlag(string currencyPair)
            => IsNdf(currencyPair) ? 'Y' : 'N';
        protected string GetNdfSettleCcy(string currencyPair)
        {
            string? ndfCurrency = NdfCurrencyPairs.FirstOrDefault(x => currencyPair.Equals(x));
            if (ndfCurrency == null)
                return "";
            else
              return  currencyPair.Replace(ndfCurrency, "");//retrieve the other currency than the ndf. So usually alway USD when the pair is ndf
        }

        protected string GetInstrument()
            => "Outright";//always outright



    }
}
