namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class Money
    {
        internal decimal Amount { get; }
        internal Currency Currency { get; }
        protected Money(Money money) : this(money.Amount, money.Currency)
        {
        }
        public Money(decimal value, Currency currency)
        {
            Amount = value;
            Currency = currency;
        }
        public Money(decimal value, string currencyCode) : this(value, new Currency(currencyCode))
        {
        }
        internal Money Truncate()
            => new Money(Math.Truncate(Amount), Currency);
        public static Money One(Currency currency)
            => new Money(1, currency);
        public static Money Zero(Currency currency)
            => new Money(0, currency);
        public bool IsPositive() => Amount > 0;

        public bool IsPositiveOrZero() => Amount >= 0;

        public bool IsNegativeOrZero() => Amount <= 0;
        public bool IsNegative() => Amount < 0;
        public Money Convert(Currency currency, Func<Currency, Currency, decimal> fxRateFunc)
            => new Money(Amount * fxRateFunc(Currency, currency), currency);
        public Money Abs()
            => new Money(Math.Abs(Amount), Currency);

        public static Money operator *(Money p1, decimal value)
            => new Money(p1.Amount * value, p1.Currency);

        public static Money operator *(decimal value, Money p1)
             => p1 * value;

        public static Money operator /(Money p1, decimal value)
             => new Money(p1.Amount / value, p1.Currency);

        public static Money operator /(decimal value, Money p1)
             => new Money(value / p1.Amount, p1.Currency);


        public static Money operator +(Money p1, decimal value)
             => new Money(p1.Amount + value, p1.Currency);

        public static Money operator +(decimal value, Money p1)
            => p1 + value;


        public static Money operator -(Money p1, decimal value)
            => new Money(p1.Amount - value, p1.Currency);

        public static Money operator -(decimal value, Money p1)
            => new Money(value - p1.Amount, p1.Currency);

        public static bool operator >(Money p1, Money p2)
        {
            if (p1.IsSameCurrency(p2))
                return p1.Amount > p2.Amount;
            throw new ArgumentException("Can't compare {p1} with {p2}, because they have different Currency");
        }

        public static bool operator <(Money p1, Money p2)
        {
            if (p1.IsSameCurrency(p2))
                return p1.Amount < p2.Amount;
            throw new ArgumentException("Can't compare {p1} with {p2}, because they have different Currency");
        }

        public static bool operator >=(Money p1, Money p2)
        {
            if (p1.IsSameCurrency(p2))
                return p1.Amount >= p2.Amount;
            throw new ArgumentException("Can't compare {p1} with {p2}, because they have different Currency");
        }



        public static bool operator <=(Money p1, Money p2)
        {
            if (p1.IsSameCurrency(p2))
                return p1.Amount <= p2.Amount;
            throw new ArgumentException("Can't compare {p1} with {p2}, because they have different Currency");
        }

        public static bool operator ==(Money p1, Money p2)
        {
            if (p1.IsSameCurrency(p2))
                return p1.Amount == p2.Amount;
            throw new ArgumentException("Can't compare {p1} with {p2}, because they have different Currency");
        }

        public static bool operator !=(Money p1, Money p2)
        {
            if (p1.IsSameCurrency(p2))
                return p1.Amount != p2.Amount;
            throw new NotSupportedException("Can't compare {p1} with {p2}, because they have different Currency");
        }



        public static Money Max(Money m1, Money m2)
        {
            if (!m1.IsSameCurrency(m2))
                throw new InvalidOperationException("Max operator can only be applied to Money having the same currency");
            return new Money(Math.Max(m1.Amount, m2.Amount), m1.Currency);
        }

        public static Money operator *(Money p1, Money p2)
            => CreateMoneyIfSameCurrency(p1, p2, p1.Amount * p2.Amount, $"Can't multiply {p1} with {p2}, because they have different Currency");

        public static Money operator /(Money p1, Money p2)
            => CreateMoneyIfSameCurrency(p1, p2, p1.Amount / p2.Amount, $"Can't divide {p1} by {p2}, because they have different Currency");

        public static Money operator +(Money p1, Money p2)
             => CreateMoneyIfSameCurrency(p1, p2, p1.Amount + p2.Amount, $"Can't sum {p1} with {p2}, because they have different Currency");

        public static Money operator -(Money p1, Money p2)
             => CreateMoneyIfSameCurrency(p1, p2, p1.Amount - p2.Amount, $"Can't substract {p1} by {p2}, because they have different Currency");

        private static Money CreateMoneyIfSameCurrency(Money p1, Money p2, decimal value, string message)
        {
            if (p1.IsSameCurrency(p2))
                return new Money(value, p1.Currency);
            else
                throw new ArgumentException(message);
        }
        public bool IsSameCurrency(Money money)
            => Currency.Equals(money.Currency);

        public override string ToString()
         => $"{Amount} {Currency}";

        public override bool Equals(object? obj)
         => obj is Money money &&
                   Amount == money.Amount &&
                   EqualityComparer<Currency>.Default.Equals(Currency, money.Currency);


        public override int GetHashCode()
         => HashCode.Combine(Amount, Currency);

    }
}
