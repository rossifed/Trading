namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class Commission
    {
        internal decimal Value { get; }

        internal CommissionType CommissionType { get; }
        public Commission(decimal value, string commissionType)
       : this(value, Enum.Parse<CommissionType>(commissionType)) { }

        internal static Commission NA() => new Commission(0, CommissionType.N);
        public Commission(decimal value, CommissionType commissionType)
        {
            Value = Math.Abs(value);
            CommissionType = commissionType;
        }
        internal Money ComputeCommissionAmount(Money grossAmount , Quantity quantity)
        {
            switch (CommissionType)
            {
                case CommissionType.L:
                    return new Money(quantity*Value, grossAmount.Currency).Abs();
                case CommissionType.R:
                    return (grossAmount * Value).Abs();
                case CommissionType.F:
                    return new Money(Value, grossAmount.Currency).Abs();
                case CommissionType.N:
                    return new Money(0, grossAmount.Currency);
                default: throw new NotSupportedException($"Commission Type {CommissionType} is not supported");

            }
        }

        public override string? ToString()
        {
            return $"{CommissionType}:{Value}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Commission commission &&
                   Value == commission.Value &&
                   CommissionType == commission.CommissionType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, CommissionType);
        }
    }
}
