namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints
{
    internal class TargetAllocationCheck
    {
        internal TargetAllocation TargetAllocation { get; }
        internal IEnumerable<ConstraintCheck> ConstraintChecks { get; }
        internal IEnumerable<ConstraintBreach> Breaches => ConstraintChecks.SelectMany(x => x.Breaches);
        internal IEnumerable<Constraint> CheckedConstraints => ConstraintChecks.Select(x => x.CheckedConstraint);
        public bool IsBreach => Breaches.Any();
      

        internal TargetAllocationCheck(TargetAllocation targetAllocation,
            IEnumerable<ConstraintCheck> constraintChecks)
        {
            this.TargetAllocation = targetAllocation;
            this.ConstraintChecks = constraintChecks;

        }

    }
}
