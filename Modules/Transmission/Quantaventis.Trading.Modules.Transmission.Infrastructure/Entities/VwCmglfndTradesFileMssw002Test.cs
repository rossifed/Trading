using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class VwCmglfndTradesFileMssw002Test
{
    public string TransactionType { get; set; } = null!;

    public string TransactionStatus { get; set; } = null!;

    public string BuySellIndicator { get; set; } = null!;

    public string? LongShortIndicator { get; set; }

    public string PositionType { get; set; } = null!;

    public string TransactionLevel { get; set; } = null!;

    public int ClientTradeRefNo { get; set; }

    public string AssociatedTradeId { get; set; } = null!;

    public string ExecutionAccount { get; set; } = null!;

    public string AccountId { get; set; } = null!;

    public string BrokerCounterparty { get; set; } = null!;

    public string SecurityIdentifierType { get; set; } = null!;

    public string? SecurityIdentifier { get; set; }

    public string SecurityDescription { get; set; } = null!;

    public string? TradeDate { get; set; }

    public string? SettlementDate { get; set; }

    public string SettlementCcy { get; set; } = null!;

    public string ExchangeCode { get; set; } = null!;

    public int? Quantity { get; set; }

    public decimal Price { get; set; }

    public string PriceIndicator { get; set; } = null!;

    public decimal? Principal { get; set; }

    public decimal? ExecutionBrokerCommission { get; set; }

    public string ExecutingBrokerCommissionIndicator { get; set; } = null!;

    public decimal MsFees { get; set; }

    public string NotRequired { get; set; } = null!;

    public string MsFeesIndicator { get; set; } = null!;

    public string DividendEntitlementPercent { get; set; } = null!;

    public string Spread { get; set; } = null!;

    public decimal? NetAmount { get; set; }

    public string HearsayInd { get; set; } = null!;

    public string Custodian { get; set; } = null!;

    public string MoneyManager { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public string DealId { get; set; } = null!;

    public string TaxLotId { get; set; } = null!;

    public string OriginalTaxlotTransactionDate { get; set; } = null!;

    public string OriginalTaxlotTransactionPrice { get; set; } = null!;

    public string TaxlotCloseoutMethod { get; set; } = null!;

    public string PriceFxRate { get; set; } = null!;

    public string AcquisitionDate { get; set; } = null!;

    public string? Comments { get; set; }

    public string SwapReferenceNo { get; set; } = null!;

    public string BasketId { get; set; } = null!;

    public string PriceCurrency { get; set; } = null!;

    public string ResetIndicator { get; set; } = null!;

    public string SnsReference { get; set; } = null!;

    public string ResearchFee { get; set; } = null!;

    public string ResearchFeeIndicator { get; set; } = null!;

    public string Lei { get; set; } = null!;

    public string ClientStrategy2UsedForPeps { get; set; } = null!;
}
