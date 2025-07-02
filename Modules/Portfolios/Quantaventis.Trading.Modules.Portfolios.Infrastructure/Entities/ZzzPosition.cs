using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;

public partial class ZzzPosition
{
    public byte PortfolioId { get; set; }

    public int InstrumentId { get; set; }

    public int Quantity { get; set; }

    public decimal AvgEntryPriceLocal { get; set; }

    public decimal PositionValueLocal { get; set; }

    public decimal GrossTotalCostLocal { get; set; }

    public decimal NetTotalCostLocal { get; set; }

    public int LastTradeAllocationId { get; set; }

    public DateTime PositionDate { get; set; }

    public string Currency { get; set; } = null!;

    public int PreviousQuantity { get; set; }

    public decimal PreviousAvgEntryPriceLocal { get; set; }

    public decimal PreviousPositionValueLocal { get; set; }

    public decimal PreviousGrossTotalCostLocal { get; set; }

    public decimal PreviousNetTotalCostLocal { get; set; }

    public DateTime? PreviousPositionDate { get; set; }

    public decimal? TotalCommissionLocal { get; set; }

    public virtual Portfolio Portfolio { get; set; } = null!;
}
