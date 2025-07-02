namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class CounterpartyRoleSetup
    {
        internal int Id { get; }
        internal Counterparty? PrimeBroker { get; }
        internal Counterparty ClearingBroker { get; }
        internal Counterparty? Custodian { get; }

        public CounterpartyRoleSetup(
            int id,
            Counterparty? primeBroker,
            Counterparty clearingBroker,
            Counterparty? custodian)
        {
            this.Id = id;
            PrimeBroker = primeBroker;
            ClearingBroker = clearingBroker;
            Custodian = custodian;
        }

        public override string? ToString()
        {
            return $"{PrimeBroker},{ClearingBroker},{Custodian}";
        }

        public override bool Equals(object? obj)
        {
            return obj is CounterpartyRoleSetup setup &&
                   Id == setup.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
