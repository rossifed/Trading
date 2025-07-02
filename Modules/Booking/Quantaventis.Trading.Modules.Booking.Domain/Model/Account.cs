namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal struct Account
    {
        internal string Code { get; }
        internal Account(string code)
        {

            Code = code;
        }


        public override string? ToString()
         => Code.ToString();

        public override bool Equals(object? obj)
        {
            return obj is Account account &&
                   Code == account.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }

        public static implicit operator Account(string code) => new(code);

        public static implicit operator string(Account account) => account.Code;

    }
}
