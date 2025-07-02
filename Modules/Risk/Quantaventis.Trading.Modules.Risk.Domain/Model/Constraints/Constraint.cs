using Quantaventis.Trading.Modules.Risk.Domain.Model;
using Quantaventis.Trading.Modules.Risk.Domain.Model.Filters;
namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal  abstract class Constraint
    {   internal int Id { get; }
        internal double LimitValue { get; }
        internal RelationalOperator RelationalOperator { get; }

        internal IFilter<IEnumerable<TargetWeight>>? Filter { get; }

        internal Constraint(int id, RelationalOperator relationalOperator, double limitValue)
        {
            this.Id = id;
            this.RelationalOperator = relationalOperator;
            this.LimitValue = limitValue;
        }
        internal Constraint(int id, RelationalOperator relationalOperator, double limitValue, IFilter<IEnumerable<TargetWeight>>? filter)
            : this(id,relationalOperator, limitValue)
        {
            this.Filter = filter;
        }

        public ConstraintCheck Check(IEnumerable<TargetWeight> targetWeights)
         => Filter == null ?
            new ConstraintCheck(this,targetWeights, CheckFiltered(targetWeights))
            :
            new ConstraintCheck(this, targetWeights, CheckFiltered(Filter.ApplyTo(targetWeights)));

        public override string? ToString()
        => $"{GetType().Name} {RelationalOperator} {LimitValue} Where {Filter}";

        protected abstract IEnumerable<ConstraintBreach> CheckFiltered(IEnumerable<TargetWeight> targetWeights);


    }
}
