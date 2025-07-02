using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class VwTradesFileCapricorn
{
    public long? OrderNumber { get; set; }

    public string? Activity { get; set; }

    public string Account { get; set; } = null!;

    public string SecurityDescription { get; set; } = null!;

    public string TickerSymbol { get; set; } = null!;

    public string? ExchangeMic { get; set; }

    public string Isin { get; set; } = null!;

    public string? Sedol { get; set; }

    public string Cusip { get; set; } = null!;

    public string Broker { get; set; } = null!;

    public string Custodian { get; set; } = null!;

    public string SecurityType { get; set; } = null!;

    public string? TransactionType { get; set; }

    public string SettlementCcy { get; set; } = null!;

    public string? TradeDate { get; set; }

    public string? SettleDate { get; set; }

    public int OrderQuantity { get; set; }

    public int FillledQuantity { get; set; }

    public decimal Commission { get; set; }

    public decimal? Price { get; set; }

    public string AccruedInterest { get; set; } = null!;

    public string SecFee { get; set; } = null!;

    public string TradeTax { get; set; } = null!;

    public decimal MiscMoney { get; set; }

    public decimal? NetAmount { get; set; }

    public decimal? Principal { get; set; }

    public string Description { get; set; } = null!;

    public int IsCfd { get; set; }

    public string ClearingAgent { get; set; } = null!;

    public string PutCall { get; set; } = null!;

    public string Strike { get; set; } = null!;

    public string? ExpiryDate { get; set; }

    public string? Trader { get; set; }
}
