using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class VwMsefrpFutureTradeAffirm
{
    public string Account { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Ccy1Side { get; set; } = null!;

    public string Ccy1 { get; set; } = null!;

    public string Ccy1Amt { get; set; } = null!;

    public int? Quantity { get; set; }

    public string Ccy2 { get; set; } = null!;

    public decimal? Ccy2Amt { get; set; }

    public decimal? SpotRate { get; set; }

    public string TradeDate { get; set; } = null!;

    public string ValueDate { get; set; } = null!;

    public string EntryUser { get; set; } = null!;

    public string DealId { get; set; } = null!;

    public string? LastUpdateTime { get; set; }

    public string? DealEntryTime { get; set; }
}
