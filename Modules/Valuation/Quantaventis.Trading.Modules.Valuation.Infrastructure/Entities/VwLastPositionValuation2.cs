using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class VwLastPositionValuation2
{
    public byte PortfolioId { get; set; }

    public int InstrumentId { get; set; }

    public int Quantity { get; set; }

    public decimal AvgEntryPriceLocal { get; set; }

    public decimal GrossTotalCostLocal { get; set; }

    public decimal NetTotalCostLocal { get; set; }

    public DateTime PositionDate { get; set; }

    public string PositionCurrency { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime PriceDate { get; set; }

    public decimal PreviousPrice { get; set; }

    public DateTime PreviousPriceDate { get; set; }

    public decimal ValuationFactor { get; set; }

    public decimal InstrumentValue { get; set; }

    public decimal PreviousInstrumentValue { get; set; }

    public decimal PriceReturn { get; set; }

    public decimal? MarketValue { get; set; }

    public decimal? Pnl { get; set; }
}
