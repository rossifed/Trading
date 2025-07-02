using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class ConstraintBreach
{
    public int ConstraintBreachId { get; set; }

    public int TargetAllocationCheckId { get; set; }

    public int ConstraintId { get; set; }

    public double LimitValue { get; set; }

    public double CheckedValue { get; set; }

    public string Message { get; set; } = null!;

    public virtual Constraint Constraint { get; set; } = null!;

    public virtual TargetAllocationCheck TargetAllocationCheck { get; set; } = null!;
}
