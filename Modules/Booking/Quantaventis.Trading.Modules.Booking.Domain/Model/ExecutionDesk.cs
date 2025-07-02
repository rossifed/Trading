namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class ExecutionDesk
    {
        internal int Id { get; }
        internal string Code { get; }
        internal Counterparty ExecutionBroker { get; }
        public ExecutionDesk(int id, string code, Counterparty executionBroker)
        {
            Id = id;
            Code = code;
            ExecutionBroker = executionBroker;
        }
        public override string? ToString()
        {
            return Code;
        }

        public override bool Equals(object? obj)
        {
            return obj is ExecutionDesk desk &&
                   Id == desk.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
