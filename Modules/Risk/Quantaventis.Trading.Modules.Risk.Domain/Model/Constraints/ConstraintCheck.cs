namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal class ConstraintCheck
    {
        public IEnumerable<TargetWeight> TargetWeights { get; }

        public Constraint CheckedConstraint { get; }

        public IEnumerable<ConstraintBreach> Breaches { get; }
        public bool IsBreach => Breaches.Any();
      

        internal ConstraintCheck(
            Constraint checkedConstraint,
            IEnumerable<TargetWeight> targetWeights,
            IEnumerable<ConstraintBreach> breaches)
        {
            this.CheckedConstraint = checkedConstraint;
            this.TargetWeights = targetWeights;
            this.Breaches = breaches;
        }

    }
}
