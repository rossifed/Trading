using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string MarketSector { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public virtual ICollection<BookedTradeAllocation> BookedTradeAllocations { get; } = new List<BookedTradeAllocation>();

    public virtual ICollection<TradeAllocation> TradeAllocations { get; } = new List<TradeAllocation>();
}
