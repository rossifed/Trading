
using Quantaventis.Trading.Modules.Risk.Domain.Model.Filters;
using System.Security.Cryptography.X509Certificates;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal class SingleGrossExposureConstraint : SingleExposureConstraint
    {
        internal SingleGrossExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue)
            : base(id,relationalOperator, limitValue) { }
        internal SingleGrossExposureConstraint(int id, RelationalOperator relationalOperator, double limitValue, IFilter<IEnumerable<TargetWeight>>? filter)
            : base(id,relationalOperator, limitValue, filter) { }
        protected override  double GetCheckedValue(TargetWeight position)
         => Math.Abs(position.Weight);


    }
}
