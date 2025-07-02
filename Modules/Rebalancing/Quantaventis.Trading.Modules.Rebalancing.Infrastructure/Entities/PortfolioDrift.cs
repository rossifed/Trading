using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;

public partial class PortfolioDrift
{
    public int PortfolioDriftId { get; set; }

    public byte PortfolioId { get; set; }

    public int PortfolioValuationId { get; set; }

    public int TargetAllocationId { get; set; }

    public int TargetAllocationValuationId { get; set; }

    public decimal PortfolioNetExposure { get; set; }

    public decimal TargetNetExposure { get; set; }

    public decimal NetExposureDrift { get; set; }

    public decimal PortfolioGrossExposure { get; set; }

    public decimal TargetGrossExposure { get; set; }

    public decimal GrossExposureDrift { get; set; }

    public DateTime ComputedOn { get; set; }

    public virtual ICollection<PositionDrift> PositionDrifts { get; } = new List<PositionDrift>();

    public virtual ICollection<RebalancingSession> RebalancingSessions { get; } = new List<RebalancingSession>();
}
