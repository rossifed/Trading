using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class VwCmglfndTradesFileGsSynthTest
{
    public string OrderNumber { get; set; } = null!;

    public string CancelCorrectIndicator { get; set; } = null!;

    public string AccountNumberOrAcronym { get; set; } = null!;

    public string? SecurityIdentifier { get; set; }

    public string Broker { get; set; } = null!;

    public string Custodian { get; set; } = null!;

    public string TransactionType { get; set; } = null!;

    public string CurrencyCode { get; set; } = null!;

    public string? TradeDate { get; set; }

    public string? SettlementDate { get; set; }

    public int Quantity { get; set; }

    public decimal? Commission { get; set; }

    public decimal Price { get; set; }

    public string AccruedInterest { get; set; } = null!;

    public string TradeTax { get; set; } = null!;

    public string MiscMoney { get; set; } = null!;

    public decimal? NetAmount { get; set; }

    public decimal? Principal { get; set; }

    public string Description { get; set; } = null!;

    public string SecurityType { get; set; } = null!;

    public string CoutrySettlementCode { get; set; } = null!;

    public string ClearingAgent { get; set; } = null!;

    public string SecFees { get; set; } = null!;

    public string OptionUnderlyer { get; set; } = null!;

    public string OptionExpiryDate { get; set; } = null!;

    public string OptionCalPutIndicator { get; set; } = null!;

    public string OptionStrikePrice { get; set; } = null!;

    public string Trailer { get; set; } = null!;

    public string Trailer1 { get; set; } = null!;

    public string Trailer2 { get; set; } = null!;

    public string Trailer3 { get; set; } = null!;

    public string Trailer4 { get; set; } = null!;
}
