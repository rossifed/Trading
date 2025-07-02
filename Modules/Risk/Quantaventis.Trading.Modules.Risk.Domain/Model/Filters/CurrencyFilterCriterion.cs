namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal class CurrencyFilterCriterion : FilterCriterion<Currency>
    {
        public CurrencyFilterCriterion(Currency party, FilterOperator<Currency> filterOperator)
            : base(party, filterOperator) { }

        protected override Currency GetParty(Instrument instrument)
           => throw new NotImplementedException();//  instrument.Currency;
    }
}
