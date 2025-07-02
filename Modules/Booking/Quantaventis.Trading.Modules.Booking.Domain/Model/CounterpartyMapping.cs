namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class CounterpartyMapping
    {
        internal byte PortfolioId { get; }
        internal string InstrumentType { get; }

        internal Counterparty ExecutionBroker { get; }
        internal Counterparty? PrimeBroker { get; }
        internal Counterparty? ClearingBroker { get; }
        internal Counterparty? Custodian { get; }
        public CounterpartyMapping(
            byte portfolioId,
            string instrumentType,
            Counterparty executionBroker)
        {
            this.PortfolioId = portfolioId;
            this.InstrumentType = instrumentType;
            ExecutionBroker = executionBroker;
        }
        public CounterpartyMapping(
            byte portfolioId,
            string instrumentType,
            Counterparty executionBroker,
            Counterparty? primeBroker,
            Counterparty? clearingBroker,
            Counterparty? custodian)
        {
            this.PortfolioId = portfolioId;
            this.InstrumentType = instrumentType;
            ExecutionBroker = executionBroker;
            PrimeBroker = primeBroker;
            ClearingBroker = clearingBroker;
            Custodian = custodian;
        }

        public override string? ToString()
        {
            return $"{PortfolioId},{InstrumentType},{ExecutionBroker}:{PrimeBroker},{ClearingBroker},{Custodian}";
        }

        public override bool Equals(object? obj)
        {
            return obj is CounterpartyMapping mapping &&
                   PortfolioId == mapping.PortfolioId &&
                   InstrumentType == mapping.InstrumentType &&
                   EqualityComparer<Counterparty>.Default.Equals(ExecutionBroker, mapping.ExecutionBroker);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PortfolioId, InstrumentType, ExecutionBroker);
        }
    }
}
