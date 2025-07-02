namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class CounterpartyRoleAssignment
    {
        internal int InstrumentId { get; }
        internal int ExecutionBrokerId { get; }
        internal byte PortfolioId { get; }
        internal CounterpartyRoleSetup CounterpartyRoleSetup { get; }

        public CounterpartyRoleAssignment(int instrumentId,
            int executionBrokerId,
            byte portfolioId,
            CounterpartyRoleSetup counterpartyRoleSetup)
        {
            InstrumentId = instrumentId;
            ExecutionBrokerId = executionBrokerId;
            PortfolioId = portfolioId;
            CounterpartyRoleSetup = counterpartyRoleSetup;
        }
        public override string? ToString()
        {
            return $"{InstrumentId}{ExecutionBrokerId}{PortfolioId}:{CounterpartyRoleSetup}";
        }

        public override bool Equals(object? obj)
        {
            return obj is CounterpartyRoleAssignment assignment &&
                   InstrumentId == assignment.InstrumentId &&
                   ExecutionBrokerId == assignment.ExecutionBrokerId &&
                   PortfolioId == assignment.PortfolioId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(InstrumentId, ExecutionBrokerId, PortfolioId);
        }
    }
}
