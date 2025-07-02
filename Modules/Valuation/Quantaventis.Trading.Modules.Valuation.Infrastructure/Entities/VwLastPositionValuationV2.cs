using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class VwLastPositionValuationV2
{
    public byte PortfolioId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public decimal PortfolioTotalValue { get; set; }

    public string PortfolioCurrency { get; set; } = null!;

    public int InstrumentId { get; set; }

    public int Quantity { get; set; }

    public decimal AvgEntryPriceLocal { get; set; }

    public decimal GrossTotalCostLocal { get; set; }

    public decimal NetTotalCostLocal { get; set; }

    public int LastTradeAllocationId { get; set; }

    public DateTime PositionDate { get; set; }

    public string Currency { get; set; } = null!;

    public int PreviousQuantity { get; set; }

    public decimal PreviousAvgEntryPriceLocal { get; set; }

    public decimal PreviousGrossTotalCostLocal { get; set; }

    public decimal PreviousNetTotalCostLocal { get; set; }

    public DateTime? PreviousPositionDate { get; set; }

    public decimal Price { get; set; }

    public DateTime PriceDate { get; set; }

    public decimal PreviousPrice { get; set; }

    public DateTime PreviousPriceDate { get; set; }

    public decimal ValuationFactor { get; set; }

    public decimal InstrumentValue { get; set; }

    public decimal PreviousInstrumentValue { get; set; }

    public decimal PriceReturn { get; set; }

    public string PriceCurrency { get; set; } = null!;

    public decimal? LocalDailyPnl { get; set; }

    public decimal? NetExposure { get; set; }

    public decimal? GrossExposure { get; set; }
}
