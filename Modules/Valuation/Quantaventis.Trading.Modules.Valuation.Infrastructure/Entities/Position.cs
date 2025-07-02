using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class Position
{
    public byte PortfolioId { get; set; }

    public int InstrumentId { get; set; }

    public int Quantity { get; set; }

    public decimal AvgEntryPriceLocal { get; set; }

    public decimal GrossTotalCostLocal { get; set; }

    public decimal NetTotalCostLocal { get; set; }

    public int LastTradeAllocationId { get; set; }

    public DateTime PositionDate { get; set; }

    public string Currency { get; set; } = null!;

    public bool IsSwap { get; set; }

    public virtual Instrument Instrument { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;
}
