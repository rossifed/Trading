using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;

public partial class PositionValuation
{
    public int PortfolioValuationId { get; set; }

    public int InstrumentId { get; set; }

    public int Quantity { get; set; }

    public decimal Weight { get; set; }

    public virtual PortfolioValuation PortfolioValuation { get; set; } = null!;
}
