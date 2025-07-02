using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class VwPositionValuationPnL
{
    public byte PortfolioId { get; set; }

    public string PortfolioCurrency { get; set; } = null!;

    public int InstrumentId { get; set; }

    public bool IsSwap { get; set; }

    public string Symbol { get; set; } = null!;

    public decimal? PnL { get; set; }

    public decimal? DailyPnLchange { get; set; }

    public string InstrumentType { get; set; } = null!;

    public string InstrumentCurrency { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal AvgEntryPriceLocal { get; set; }

    public decimal? AvgEntryPriceBase { get; set; }

    public decimal? PositionValueLocal { get; set; }

    public decimal? PositionValueBase { get; set; }

    public decimal GrossTotalCostLocal { get; set; }

    public decimal? GrossTotalCostBase { get; set; }

    public decimal NetTotalCostLocal { get; set; }

    public decimal? NetTotalCostBase { get; set; }

    public int LastTradeAllocationId { get; set; }

    public DateTime PositionDate { get; set; }

    public string PositionCurrency { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? PriceCurrency { get; set; }

    public decimal? PointValue { get; set; }

    public decimal? FxRate { get; set; }

    public decimal? InstrumentValueLocal { get; set; }

    public decimal? InstrumentValueBase { get; set; }
}
