namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal class RegionFilterCriterion : FilterCriterion<Region>
    {
        public RegionFilterCriterion(Region party, FilterOperator<Region> filterOperator)
            : base(party, filterOperator) { }

        protected override Region GetParty(Instrument instrument)
          => throw new NotImplementedException();//  instrument.Region;
    }
}
