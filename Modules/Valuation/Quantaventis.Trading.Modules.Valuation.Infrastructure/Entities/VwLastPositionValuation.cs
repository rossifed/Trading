using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class VwLastPositionValuation
{
    public int PositionValuationId { get; set; }

    public int PortfolioValuationId { get; set; }

    public DateTime ValuationDate { get; set; }

    public decimal PortfolioTotalValue { get; set; }

    public string BaseCurrency { get; set; } = null!;

    public decimal PortfolioGrossExposure { get; set; }

    public decimal PortfolioNetExposure { get; set; }

    public decimal PortfolioPnl { get; set; }

    public decimal PortfolioRoi { get; set; }

    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string InstrumentCurrency { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal InstrumentValue { get; set; }

    public decimal InstrumentPrice { get; set; }

    public DateTime InstrumentPriceDate { get; set; }

    public string InstrumentPriceCurrency { get; set; } = null!;

    public string ValuationCurrency { get; set; } = null!;

    public decimal FxRate { get; set; }

    public decimal PositionNetExposure { get; set; }

    public decimal PositionGrossExposure { get; set; }

    public decimal PositionPnl { get; set; }

    public decimal PositionRoi { get; set; }

    public decimal PositionWeight { get; set; }
}
