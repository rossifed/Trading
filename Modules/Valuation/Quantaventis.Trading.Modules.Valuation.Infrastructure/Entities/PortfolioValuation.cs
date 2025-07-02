using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class PortfolioValuation
{
    public int PortfolioValuationId { get; set; }

    public byte PortfolioId { get; set; }

    public decimal TotalValue { get; set; }

    public decimal GrossExposure { get; set; }

    public decimal NetExposure { get; set; }

    public decimal PnL { get; set; }

    public decimal Roi { get; set; }

    public string Currency { get; set; } = null!;

    public DateTime ValuationDate { get; set; }

    public virtual ICollection<PositionValuation> PositionValuations { get; } = new List<PositionValuation>();
}
