namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal class SingleCriterionFilterEvaluation : IFilterCriteriaEvaluation<Instrument>
    {

        private IFilterCriterion FilterCriterion1 { get; }

        internal SingleCriterionFilterEvaluation(IFilterCriterion filterCriterion1)
        {
            this.FilterCriterion1 = filterCriterion1;
        }

        public bool Evaluate(Instrument instrument)
          => FilterCriterion1.Evaluate(instrument);

        public override string? ToString()
         => FilterCriterion1.ToString();

    }
}
