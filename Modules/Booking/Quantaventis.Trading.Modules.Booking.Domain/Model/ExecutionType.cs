namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class ExecutionType
    {
        internal int Id { get; }
        internal string Code { get; }
        public ExecutionType(int id, string code)
        {
            Id = id;
            Code = code;
        }

        public override string? ToString()
        {
            return Code;
        }

        public override bool Equals(object? obj)
        {
            return obj is ExecutionType type &&
                   Id == type.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
