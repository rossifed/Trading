using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;

public partial class Portfolio
{
    public byte PortfolioId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public virtual ICollection<BookedTradeAllocation> BookedTradeAllocations { get; } = new List<BookedTradeAllocation>();

    public virtual ICollection<Position> Positions { get; } = new List<Position>();

    public virtual ICollection<TradeAllocation> TradeAllocations { get; } = new List<TradeAllocation>();

    public virtual ICollection<ZzzPosition> ZzzPositions { get; } = new List<ZzzPosition>();
}
