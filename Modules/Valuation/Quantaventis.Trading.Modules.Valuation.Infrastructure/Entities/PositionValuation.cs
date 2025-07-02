using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class PositionValuation
{
    public int PositionValuationId { get; set; }

    public int PortfolioValuationId { get; set; }

    public int InstrumentId { get; set; }

    public int Quantity { get; set; }

    public decimal InstrumentValue { get; set; }

    public decimal InstrumentPrice { get; set; }

    public DateTime InstrumentPriceDate { get; set; }

    public string InstrumentPriceCurrency { get; set; } = null!;

    public string ValuationCurrency { get; set; } = null!;

    public decimal FxRate { get; set; }

    public decimal NetExposure { get; set; }

    public decimal GrossExposure { get; set; }

    public decimal PnL { get; set; }

    public decimal Roi { get; set; }

    public decimal Weight { get; set; }

    public virtual PortfolioValuation PortfolioValuation { get; set; } = null!;
}
