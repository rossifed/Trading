namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal  class MultiCriteriaFilterEvaluation : IFilterCriteriaEvaluation<Instrument>
    {

        private IFilterCriterion FilterCriterion1 { get; }

        private BooleanOperator BooleanOperator { get; }
        private IFilterCriterion FilterCriterion2 { get; }


        internal MultiCriteriaFilterEvaluation(IFilterCriterion filterCriterion1, BooleanOperator booleanOperator, IFilterCriterion filterCriterion2)
        {
            this.FilterCriterion1 = filterCriterion1;
            this.FilterCriterion2 = filterCriterion2;
            this.BooleanOperator = booleanOperator;
        }



        public bool Evaluate(Instrument instrument)
          => BooleanOperator.Apply(FilterCriterion1.Evaluate(instrument), FilterCriterion2.Evaluate(instrument));
        public override string? ToString()
        {
            return $"{ FilterCriterion1} {BooleanOperator} {FilterCriterion2}";
        }
    }
}
