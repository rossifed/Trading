using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class TradeFill
{
    public int TradeFillId { get; set; }

    public int TradeId { get; set; }

    public int? EmsxTradeFillId { get; set; }

    public int? FilledQuantity { get; set; }

    public decimal? FilledPrice { get; set; }

    public DateTime FilledOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual Trade Trade { get; set; } = null!;
}
