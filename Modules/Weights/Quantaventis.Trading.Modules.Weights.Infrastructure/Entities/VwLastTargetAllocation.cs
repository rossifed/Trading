using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;

public partial class VwLastTargetAllocation
{
    public int TargetAllocationId { get; set; }

    public DateTime GeneratedOn { get; set; }

    public byte PortfolioId { get; set; }

    public string Symbol { get; set; } = null!;

    public decimal Weight { get; set; }
}
