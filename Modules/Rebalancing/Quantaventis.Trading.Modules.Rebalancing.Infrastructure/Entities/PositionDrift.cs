using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;

public partial class PositionDrift
{
    public int PortfolioDriftId { get; set; }

    public int InstrumentId { get; set; }

    public decimal TargetWeight { get; set; }

    public decimal CurrentWeight { get; set; }

    public decimal WeightDrift { get; set; }

    public int TargetQuantity { get; set; }

    public int CurrentQuantity { get; set; }

    public int QuantityDrift { get; set; }

    public virtual PortfolioDrift PortfolioDrift { get; set; } = null!;
}
