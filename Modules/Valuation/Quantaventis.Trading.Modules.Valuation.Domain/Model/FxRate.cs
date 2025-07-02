namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
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

        public FxRate UpdateValue(decimal newRate)
            => new FxRate(newRate,BaseCurrency, QuoteCurrency);
        public static Money operator *(FxRate fxRate, Money money)
         => throw new NotImplementedException();

        public static Money operator *(Money money, FxRate fxRate)
             => new Money(money.Amount * fxRate.Value, fxRate.QuoteCurrency);

        internal FxRate Invert() => new FxRate(1/Value, QuoteCurrency, BaseCurrency);
    }
}
