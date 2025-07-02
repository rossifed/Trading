namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal class InstrumentTypeFilterCriterion : FilterCriterion<InstrumentType>
    {
        public InstrumentTypeFilterCriterion(InstrumentType party, FilterOperator<InstrumentType> filterOperator)
            : base(party, filterOperator) { }

        protected override InstrumentType GetParty(Instrument instrument)
           => throw new NotImplementedException();// instrument.InstrumentType;
    }
}
