using Quantaventis.Trading.Modules.Risk.Domain.Model.Filters;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal abstract class SingleExposureConstraint : Constraint
    {
        internal SingleExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue)
            : base(id,relationalOperator, limitValue) { }
        internal SingleExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue, IFilter<IEnumerable<TargetWeight>>? filter)
            : base(id,relationalOperator, limitValue, filter) { }
        protected abstract double GetCheckedValue(TargetWeight targetWeight);
        protected override IEnumerable<ConstraintBreach> CheckFiltered(IEnumerable<TargetWeight> targetWeights)
            => targetWeights.Where(x => !Accept(x))
            .Select(x => new ConstraintBreach(this, x, GetCheckedValue(x)));

        private bool Accept(TargetWeight targetWeight)
          => RelationalOperator.Apply(GetCheckedValue(targetWeight), LimitValue);

    }
}
