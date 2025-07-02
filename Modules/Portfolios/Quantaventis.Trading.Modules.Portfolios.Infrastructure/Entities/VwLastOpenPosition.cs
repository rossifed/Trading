using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;

public partial class VwLastOpenPosition
{
    public byte PortfolioId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string BaseCurrency { get; set; } = null!;

    public int InstrumentId { get; set; }

    public bool IsSwap { get; set; }

    public string Symbol { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string MarketSector { get; set; } = null!;

    public string InstrumentName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal AvgEntryPriceLocal { get; set; }

    public decimal PositionValueLocal { get; set; }

    public decimal GrossTotalCostLocal { get; set; }

    public decimal NetTotalCostLocal { get; set; }

    public int LastTradeAllocationId { get; set; }

    public DateTime PositionDate { get; set; }

    public string Currency { get; set; } = null!;
}
