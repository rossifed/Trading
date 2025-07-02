namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal readonly struct Quantity
    {
        internal int Value { get; }
        internal Quantity(int value)
        {

            Value = value;
        }
        internal int ToInt32()
            => Convert.ToInt32(Value);
        internal Quantity AdjustSign(TradeSide tradeSide)
             => tradeSide.IsBuy() ? Abs() : Negate();
        public override string? ToString()
         => Value.ToString();

        internal Quantity Negate() => new Quantity(-Math.Abs(Value));
        internal Quantity Abs() => new Quantity(Math.Abs(Value));


        public static implicit operator Quantity(int value) => new(value);

        public static implicit operator int(Quantity quantity) => quantity.Value;

    }
}
