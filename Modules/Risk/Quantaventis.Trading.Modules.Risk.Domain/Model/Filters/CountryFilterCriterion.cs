namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal class CountryFilterCriterion : FilterCriterion<Country>
    {
        public CountryFilterCriterion(Country party, FilterOperator<Country> filterOperator)
            : base(party, filterOperator) { }

        protected override Country GetParty(Instrument instrument)
         => throw new NotImplementedException();// instrument.Country;
    }
}
