using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class TargetAllocationCheck
{
    public int TargetAllocationCheckId { get; set; }

    public int TargetAllocationId { get; set; }

    public bool IsBreach { get; set; }

    public DateTime CheckedOn { get; set; }

    public virtual ICollection<ConstraintBreach> ConstraintBreaches { get; } = new List<ConstraintBreach>();
}
