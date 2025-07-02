using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal readonly struct Currency
    {
        internal string Code { get; }
        internal Currency(string code)
        {
            if (IsValidCurrencyCode(code))
                throw new ArgumentException($"{code} is not a valid Currency Code");
            this.Code = code;
        }
        internal static Currency FromIsoCode(string code)
         => new Currency(code);

        public override string? ToString()
         => Code;

        internal static bool IsValidCurrencyCode(string code)
            => code.Length != 3 && !code.All(Char.IsLetter);

        public override bool Equals(object? obj)
        {
            return obj is Currency currency &&
                   Code == currency.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }



        public static implicit operator Currency(string code) => new(code);

        public static implicit operator string(Currency currency) => currency.Code;

    }
}
