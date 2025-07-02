using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class EmsxOrder
{
    public int EmsxSequence { get; set; }

    public int? OrderNumber { get; set; }

    public string? OrderRefId { get; set; }

    public string? Status { get; set; }

    public string Ticker { get; set; } = null!;

    public string? Isin { get; set; }

    public string? Sedol { get; set; }

    public string? Exchange { get; set; }

    public string Side { get; set; } = null!;

    public int Amount { get; set; }

    public int Filled { get; set; }

    public decimal AvgPrice { get; set; }

    public decimal? DayAvgPrice { get; set; }

    public decimal? LimitPrice { get; set; }

    public decimal Principal { get; set; }

    public decimal? BrokerCommm { get; set; }

    public decimal? CommmRate { get; set; }

    public decimal? MiscFees { get; set; }

    public string? OrderType { get; set; }

    public string? TimeInForce { get; set; }

    public string? Strategy { get; set; }

    public string HandInstruction { get; set; } = null!;

    public string Broker { get; set; } = null!;

    public string Account { get; set; } = null!;

    public string? CfdFlag { get; set; }

    public string? SettleCurrency { get; set; }

    public decimal? SettleAmount { get; set; }

    public string? ClearingAccount { get; set; }

    public string? ClearingFirm { get; set; }

    public string? BasketName { get; set; }

    public string? CustomNote1 { get; set; }

    public string? CustomNote2 { get; set; }

    public string? CustomNote3 { get; set; }

    public string? CustomNote4 { get; set; }

    public string? CustomNote5 { get; set; }

    public string? Notes { get; set; }

    public int? TraderUuid { get; set; }

    public string? Trader { get; set; }

    public DateTime? EmsxDate { get; set; }

    public double? PercentRemain { get; set; }

    public string YellowKey { get; set; } = null!;

    public DateTime? SettleDate { get; set; }

    public TimeSpan? TimeStamp { get; set; }

    public DateTime? LastFillDate { get; set; }
}
