namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal class SectorFilterCriterion : FilterCriterion<Sector>
    {
        public SectorFilterCriterion(Sector party, FilterOperator<Sector> filterOperator)
            : base(party, filterOperator) { }
        protected override Sector GetParty(Instrument instrument)
           => throw new NotImplementedException();//  instrument.Sector;
    }
}
