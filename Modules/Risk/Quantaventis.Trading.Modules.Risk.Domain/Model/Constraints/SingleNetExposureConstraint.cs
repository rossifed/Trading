using Quantaventis.Trading.Modules.Risk.Domain.Model.Filters;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal class SingleNetExposureConstraint : SingleExposureConstraint
    {
        internal SingleNetExposureConstraint(int id,RelationalOperator relationalOperator, double limitValue)
            : base(id, relationalOperator, limitValue) { }
        internal SingleNetExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue, IFilter<IEnumerable<TargetWeight>>? filter)
            : base(id, relationalOperator, limitValue, filter) { }
        protected override double GetCheckedValue(TargetWeight position)
         => position.Weight;



    }
}
