using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class VwTradesFileMsd01
{
    public string TransactionType { get; set; } = null!;

    public string Account { get; set; } = null!;

    public int ClientRefNo { get; set; }

    public string VersionNumber { get; set; } = null!;

    public string TransactionStatus { get; set; } = null!;

    public string SecIdentifierType { get; set; } = null!;

    public string SecIdentifier { get; set; } = null!;

    public string ContractYear { get; set; } = null!;

    public string ContractMonth { get; set; } = null!;

    public string ContractDay { get; set; } = null!;

    public string ContractSecurityDescription { get; set; } = null!;

    public string? MarketExchange { get; set; }

    public string BuySellIndicator { get; set; } = null!;

    public string TradeType { get; set; } = null!;

    public string OrderToCloseInd { get; set; } = null!;

    public string AveragePriceInd { get; set; } = null!;

    public string SpreadTradeInd { get; set; } = null!;

    public string NightTradeInd { get; set; } = null!;

    public string ExchangeForPhysicalInd { get; set; } = null!;

    public string BlockTradeInd { get; set; } = null!;

    public string OffExchangeInd { get; set; } = null!;

    public string? TradeDate { get; set; }

    public string ExecutionTime { get; set; } = null!;

    public int? Quantity { get; set; }

    public decimal Price { get; set; }

    public string CallPut { get; set; } = null!;

    public string StrikePrice { get; set; } = null!;

    public string ExecutingBroker { get; set; } = null!;

    public string ClearingBroker { get; set; } = null!;

    public string GiveUpReference { get; set; } = null!;

    public string HearsayInd { get; set; } = null!;

    public string ExecutionFee { get; set; } = null!;

    public string ExecutionFeeCcy { get; set; } = null!;

    public decimal Commission { get; set; }

    public string CommissionCcy { get; set; } = null!;

    public decimal ExchangeFee { get; set; }

    public string ExchangeFeeCcy { get; set; } = null!;

    public int? OrderId { get; set; }

    public string DealId { get; set; } = null!;

    public string ExecutionType { get; set; } = null!;
}
