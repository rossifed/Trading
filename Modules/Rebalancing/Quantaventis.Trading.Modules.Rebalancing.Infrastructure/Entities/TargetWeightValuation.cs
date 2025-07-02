using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;

public partial class TargetWeightValuation
{
    public int TargetAllocationValuationId { get; set; }

    public int InstrumentId { get; set; }

    public decimal Weight { get; set; }

    public int TargetQuantity { get; set; }

    public virtual TargetAllocationValuation TargetAllocationValuation { get; set; } = null!;
}
