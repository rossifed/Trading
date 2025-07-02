namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal class ConstraintBreach 
    {
        public IEnumerable<TargetWeight> TargetWeights { get; }

        internal Constraint Constraint { get; }

        internal double LimitValue => Constraint.LimitValue;
        public double CheckedValue { get; }

        public string Message { get; }
        internal ConstraintBreach(Constraint constraint, TargetWeight targetWeight,  double checkedValue)
            : this (constraint, new List<TargetWeight> {targetWeight}, checkedValue)
        {
        }

        internal ConstraintBreach(Constraint constraint, IEnumerable<TargetWeight> targetWeights, double checkedValue)
        {
            this.Constraint = constraint;
            this.CheckedValue = checkedValue;
            this.TargetWeights = targetWeights;
            this.Message = CreateMessage();
        }
        private string CreateMessage()
            => TargetWeights.Count() == 1?
             $"TargetWeight {TargetWeights.Single()} breached {Constraint}: CheckedValue:{CheckedValue}"
            : $"{TargetWeights.Count()} Target Weights breached {Constraint}: CheckedValue:{CheckedValue}";
    }
}
