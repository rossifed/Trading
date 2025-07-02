using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;

public partial class TargetWeight
{
    public int TargetAllocationId { get; set; }

    public int InstrumentId { get; set; }

    public decimal Weight { get; set; }

    public virtual Instrument Instrument { get; set; } = null!;

    public virtual TargetAllocation TargetAllocation { get; set; } = null!;
}
