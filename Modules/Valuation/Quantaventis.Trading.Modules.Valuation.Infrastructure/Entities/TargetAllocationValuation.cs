using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class TargetAllocationValuation
{
    public int TargetAllocationValuationId { get; set; }

    public int TargetAllocationId { get; set; }

    public string ValuationCurrency { get; set; } = null!;

    public decimal PortfolioValue { get; set; }

    public decimal TargetNetExposure { get; set; }

    public decimal TargetGrossExposure { get; set; }

    public decimal TotalWeight { get; set; }

    public DateTime ValuatedOn { get; set; }

    public virtual ICollection<TargetWeightValuation> TargetWeightValuations { get; } = new List<TargetWeightValuation>();
}
