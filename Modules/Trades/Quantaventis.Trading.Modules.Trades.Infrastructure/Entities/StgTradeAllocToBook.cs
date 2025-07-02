using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class StgTradeAllocToBook
{
    public int StgTradeAllocToBookId { get; set; }

    public int? StgTradeToBookId { get; set; }

    public byte? PortfolioId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? GrossAmount { get; set; }

    public decimal? NetAmount { get; set; }

    public decimal? Commission { get; set; }

    public decimal? Fees { get; set; }

    public string? PositionSide { get; set; }

    public string? TradingAccount { get; set; }

    public virtual StgTradeToBook? StgTradeToBook { get; set; }
}
