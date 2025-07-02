using Quantaventis.Trading.Modules.Risk.Domain.Model.Filters;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal  class GlobalNetExposureConstraint : GlobalExposureConstraint
    {
        internal GlobalNetExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue)
            : base(id, relationalOperator, limitValue) { }
        internal GlobalNetExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue, IFilter<IEnumerable<TargetWeight>>? filter)
            : base(id,relationalOperator, limitValue, filter) { }
        protected override double GetCheckedValue(IEnumerable<TargetWeight> targetWeights)
            => targetWeights.Sum(x => x.Weight);
 

    }
}
