namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal abstract class FilterCriterion<T> : IFilterCriterion where T : class
    {
        internal T Party { get; }

        internal FilterOperator<T> Operator { get; }

        internal FilterCriterion(T party, FilterOperator<T> filterOperator)
        {
            Party = party;
            Operator = filterOperator;
        }
        protected abstract T GetParty(Instrument instrument);
        public bool Evaluate(Instrument instrument)
        {
            T instrumentParty = GetParty(instrument);
            return Operator.Apply(instrumentParty, Party);
        }

        public override string? ToString()
         => $"{Party.GetType().Name} {Operator} {Party}";

    }
}
