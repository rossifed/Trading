using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class TargetWeightValuation
{
    public int TargetWeightValuationId { get; set; }

    public int TargetAllocationValuationId { get; set; }

    public int InstrumentId { get; set; }

    public decimal Weight { get; set; }

    public decimal Price { get; set; }

    public DateTime PricedOn { get; set; }

    public string PriceCurrency { get; set; } = null!;

    public decimal InstrumentValue { get; set; }

    public int TargetQuantity { get; set; }

    public decimal TargetNetExposure { get; set; }

    public decimal TargetGrossExposure { get; set; }

    public virtual TargetAllocationValuation TargetAllocationValuation { get; set; } = null!;
}
