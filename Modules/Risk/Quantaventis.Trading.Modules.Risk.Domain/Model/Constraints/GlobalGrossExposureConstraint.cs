using Quantaventis.Trading.Modules.Risk.Domain.Model.Filters;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal  class GlobalGrossExposureConstraint : GlobalExposureConstraint
    {
        internal GlobalGrossExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue)
            : base(id,relationalOperator, limitValue) { }
        internal GlobalGrossExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue, IFilter<IEnumerable<TargetWeight>>? filter)
            : base(id,relationalOperator, limitValue, filter) { }
        protected override double GetCheckedValue(IEnumerable<TargetWeight> targetWeights)
            => targetWeights.Sum(x => Math.Abs(x.Weight));
 

    }
}
