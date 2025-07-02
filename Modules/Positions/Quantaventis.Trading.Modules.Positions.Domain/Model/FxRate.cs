using Microsoft.Win32.SafeHandles;

namespace Quantaventis.Trading.Modules.Positions.Domain.Model
{
    internal readonly struct FxRate
    {
        internal Currency BaseCurrency { get; }
        internal Currency QuoteCurrency { get; }
        internal decimal Value { get; }
       internal FxRate(decimal value,Currency baseCurrency, Currency quoteCurrency) {
            this.BaseCurrency = baseCurrency;
            this.QuoteCurrency = quoteCurrency;
            this.Value = value;
        }

        internal static FxRate One(Currency ccy)
            => new FxRate(1, ccy, ccy);

        public FxRate UpdateValue(decimal newRate)
            => new FxRate(newRate,BaseCurrency, QuoteCurrency);
        public static Money operator *(FxRate fxRate, Money money)
         => throw new NotImplementedException();

        public static Money operator *(Money money, FxRate fxRate)
             => new Money(money.Amount * fxRate.Value, fxRate.QuoteCurrency);

        internal FxRate Invert() => new FxRate(1/Value, QuoteCurrency, BaseCurrency);
    }
}
