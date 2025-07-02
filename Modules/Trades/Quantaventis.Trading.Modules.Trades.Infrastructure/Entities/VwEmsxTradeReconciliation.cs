using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class VwEmsxTradeReconciliation
{
    public int? EmsxSequence { get; set; }

    public int? BookedSequence { get; set; }

    public int? TradeId { get; set; }

    public string? EmsxSymbol { get; set; }

    public string? BookedSymbol { get; set; }

    public int? EmsxQuantity { get; set; }

    public int? BookedQuantity { get; set; }

    public int? QuantityDiff { get; set; }

    public int? SignDiff { get; set; }

    public string? EmsxPrice { get; set; }

    public decimal? BookedPrice { get; set; }

    public decimal? PriceDiff { get; set; }

    public string? EmsxTradeDate { get; set; }

    public DateTime? BookedTradeDate { get; set; }

    public int TradeDateDiff { get; set; }

    public string? EmsxCurrency { get; set; }

    public string? BookedCurrency { get; set; }

    public int CurrencyDiff { get; set; }
}
