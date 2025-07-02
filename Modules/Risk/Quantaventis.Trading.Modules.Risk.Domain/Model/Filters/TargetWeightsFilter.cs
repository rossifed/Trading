using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal class TargetWeightsFilter : IFilter<IEnumerable<TargetWeight>>
    {
        private IFilterCriteriaEvaluation<Instrument> FilterCriteriaEvaluation { get; }
        internal TargetWeightsFilter(IFilterCriterion filterCriterion1, BooleanOperator booleanOperator, IFilterCriterion filterCriterion2)
        {
            this.FilterCriteriaEvaluation = new MultiCriteriaFilterEvaluation(filterCriterion1, booleanOperator, filterCriterion2);
        }
        internal TargetWeightsFilter(IFilterCriterion filterCriterion)
        {
            this.FilterCriteriaEvaluation = new SingleCriterionFilterEvaluation(filterCriterion);
        }
        public IEnumerable<TargetWeight> ApplyTo(IEnumerable<TargetWeight> targetWeights)
         => targetWeights
             .Where(x => FilterCriteriaEvaluation.Evaluate(x.Instrument));

        public override string? ToString()
         => FilterCriteriaEvaluation.ToString();
    
    }
}
