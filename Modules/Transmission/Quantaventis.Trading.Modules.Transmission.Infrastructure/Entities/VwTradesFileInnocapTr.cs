using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class VwTradesFileInnocapTr
{
    public string TrasactionType { get; set; } = null!;

    public string TransactionStatus { get; set; } = null!;

    public string BuySell { get; set; } = null!;

    public string? LongShort { get; set; }

    public string PositionType { get; set; } = null!;

    public string TransLevel { get; set; } = null!;

    public int ClientRef { get; set; }

    public string Associated { get; set; } = null!;

    public string ExecAccount { get; set; } = null!;

    public string AccountId { get; set; } = null!;

    public string ExecutionBroker { get; set; } = null!;

    public string SecType { get; set; } = null!;

    public string SecId { get; set; } = null!;

    public string SecurityDescription { get; set; } = null!;

    public string? TradeDate { get; set; }

    public string? SettlementDate { get; set; }

    public string SettlementCurrency { get; set; } = null!;

    public string ExchangeCode { get; set; } = null!;

    public int? Quantity { get; set; }

    public decimal? PriceAmount { get; set; }

    public string PriceIndicator { get; set; } = null!;

    public decimal? Principal { get; set; }

    public decimal? CommissionAmount { get; set; }

    public string CommissionIndicator { get; set; } = null!;

    public decimal? TaxFees { get; set; }

    public string Tax2 { get; set; } = null!;

    public string FeeInd { get; set; } = null!;

    public string Interest { get; set; } = null!;

    public string InterestIndicator { get; set; } = null!;

    public decimal? NetAmount { get; set; }

    public string HearsayInd { get; set; } = null!;

    public string Custodian { get; set; } = null!;

    public string MoneyManager { get; set; } = null!;

    public string BookId { get; set; } = null!;

    public string DealId { get; set; } = null!;

    public string TaxLotId { get; set; } = null!;

    public string TaxDate { get; set; } = null!;

    public string TaxPrice { get; set; } = null!;

    public string CloseOutMethod { get; set; } = null!;

    public string ExRate { get; set; } = null!;

    public string AcqDate { get; set; } = null!;

    public string Comments { get; set; } = null!;
}
