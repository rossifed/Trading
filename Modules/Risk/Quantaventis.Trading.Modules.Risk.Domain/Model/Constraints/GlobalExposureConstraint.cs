using Quantaventis.Trading.Modules.Risk.Domain.Model.Filters;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal abstract class GlobalExposureConstraint : Constraint
    {
        internal GlobalExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue)
            : base(id,relationalOperator, limitValue) { }
        internal GlobalExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue, IFilter<IEnumerable<TargetWeight>>? filter)
            : base(id, relationalOperator, limitValue, filter) { }
        protected abstract double GetCheckedValue(IEnumerable<TargetWeight> targetWeights);
        protected override IEnumerable<ConstraintBreach> CheckFiltered(IEnumerable<TargetWeight> targetWeights)
            => !Accept(targetWeights) 
            ? new List<ConstraintBreach>() { new ConstraintBreach(this, targetWeights, GetCheckedValue(targetWeights)) }
            : Enumerable.Empty<ConstraintBreach>();

        private bool Accept(IEnumerable<TargetWeight> targetWeights)
          => RelationalOperator.Apply(GetCheckedValue(targetWeights), LimitValue);

    }
}
