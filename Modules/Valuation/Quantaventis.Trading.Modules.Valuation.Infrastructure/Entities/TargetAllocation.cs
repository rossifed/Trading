using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class TargetAllocation
{
    public int TargetAllocationId { get; set; }

    public byte PortfolioId { get; set; }

    public DateTime GeneratedOn { get; set; }

    public virtual Portfolio Portfolio { get; set; } = null!;

    public virtual ICollection<TargetWeight> TargetWeights { get; } = new List<TargetWeight>();
}
