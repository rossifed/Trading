namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal struct Exchange
    {
        internal string Code { get; }
        internal Exchange(string code)
        {
            Code = code;
        }

        public override string? ToString()
         => Code.ToString();

        public static implicit operator Exchange(string code) => new(code);

        public static implicit operator string(Exchange exchange) => exchange.Code;
    }
}
