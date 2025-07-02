using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class VwEfrpTrade
{
    public string Exchange { get; set; } = null!;

    public int InstrumentId { get; set; }

    public int? GenericFutureId { get; set; }

    public decimal? FuturePointValue { get; set; }

    public string Symbol { get; set; } = null!;

    public string? BuySellIndicator { get; set; }

    public double? Quantity { get; set; }

    public string Currency { get; set; } = null!;

    public decimal? Ccy2Amt { get; set; }

    public double? SpotRate { get; set; }

    public DateTime? TradeDate { get; set; }

    public double? AvgPrice { get; set; }

    public double? Principal { get; set; }

    public double? NetAmount { get; set; }

    public double? BrokerCommm { get; set; }

    public double? CommmRate { get; set; }

    public int MiscFees { get; set; }

    public string InstrumentCurrency { get; set; } = null!;
}
