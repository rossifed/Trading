namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal struct TradeSide
    {
        private static string BUY_CODE = "B";
        private static string SELL_CODE = "S";
        internal string Code { get; }
        internal TradeSide(string code)
        {

            Code = code;
        }
        internal bool IsBuy() => Code.Equals(BUY_CODE);
        internal bool IsSell() => Code.Equals(SELL_CODE);
        internal static TradeSide Buy => new TradeSide("B");
        internal static TradeSide Sell => new TradeSide("S");

        internal static bool IsBuy(string sideCode)
            => sideCode.Trim().ToUpper().First() == 'B';

        internal static bool IsSell(string sideCode)
             => sideCode.Trim().ToUpper().First() == 'S';
        public override string? ToString()
         => Code.ToString();
        internal static TradeSide Parse(string sideCode)
        {
            if (IsBuy(sideCode))
                return Buy;
            if (IsSell(sideCode))
                return Sell;

            throw new InvalidOperationException($"TradeSide can't be infered from side code {sideCode}");

        }

        internal static TradeSide FromQuantity(int quantity) {
            if (quantity > 0)
                return TradeSide.Buy;
            if (quantity < 0)
                return TradeSide.Sell;
            throw new InvalidOperationException($"Trade Side couldn't be infered from Quantity {quantity}");
        }
        public override bool Equals(object? obj)
        {
            return obj is TradeSide side &&
                   Code == side.Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }

        public static implicit operator TradeSide(string code) => new(code);

        public static implicit operator string(TradeSide account) => account.Code;
    }
}
