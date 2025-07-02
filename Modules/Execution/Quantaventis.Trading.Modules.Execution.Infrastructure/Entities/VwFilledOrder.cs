using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;

public partial class VwFilledOrder
{
    public int EmsxSequence { get; set; }

    public int OrderNumer { get; set; }

    public string? OrderRefId { get; set; }

    public string? Status { get; set; }

    public string? Ticker { get; set; }

    public string? Isin { get; set; }

    public string? Sedol { get; set; }

    public string? Exchange { get; set; }

    public string Side { get; set; } = null!;

    public int? Amount { get; set; }

    public int? Filled { get; set; }

    public decimal? AvgPrice { get; set; }

    public decimal? DayAvgPrice { get; set; }

    public decimal? LimitPrice { get; set; }

    public decimal? Principal { get; set; }

    public int BrokerComm { get; set; }

    public int CommRate { get; set; }

    public int MiscFees { get; set; }

    public string? OrderType { get; set; }

    public string? TimeInForce { get; set; }

    public string? Strategy { get; set; }

    public string? HandlingInstruction { get; set; }

    public string? Broker { get; set; }

    public string? Account { get; set; }

    public string CfdFlag { get; set; } = null!;

    public string? SettleCurrency { get; set; }

    public decimal? SettleAmount { get; set; }

    public string? ClearingAccount { get; set; }

    public string? ClearingFirm { get; set; }

    public string? BasketName { get; set; }

    public string? CustomNote1 { get; set; }

    public string? CustomNote2 { get; set; }

    public string? CustomNote4 { get; set; }

    public string? CustomNote5 { get; set; }

    public string? Notes { get; set; }

    public int? TraderUuid { get; set; }

    public string? Trader { get; set; }

    public DateTime? EmsxDate { get; set; }

    public decimal? PercentRemain { get; set; }

    public string? YellowKey { get; set; }

    public DateTime? SettlementDate { get; set; }

    public DateTime? TimeStamp { get; set; }

    public DateTime? LastFillDate { get; set; }
}
