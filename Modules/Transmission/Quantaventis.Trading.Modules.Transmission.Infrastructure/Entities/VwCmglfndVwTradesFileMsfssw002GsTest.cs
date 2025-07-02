using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class VwCmglfndVwTradesFileMsfssw002GsTest
{
    public string TrasationType { get; set; } = null!;

    public string TransactionStatus { get; set; } = null!;

    public string BuySell { get; set; } = null!;

    public string? LongShort { get; set; }

    public string PositionType { get; set; } = null!;

    public string TransLevel { get; set; } = null!;

    public int ClientTradeRefNo { get; set; }

    public string AssociatedTradeId { get; set; } = null!;

    public string ExecutionAccount { get; set; } = null!;

    public string AccountId { get; set; } = null!;

    public string BrokerCouterparty { get; set; } = null!;

    public string SecurityIdentifierType { get; set; } = null!;

    public string? SecurityIdentifier { get; set; }

    public string SecurityDescription { get; set; } = null!;

    public string? TradeDate { get; set; }

    public string? SettlementDate { get; set; }

    public string SettlementCurrency { get; set; } = null!;

    public string ExchangeCode { get; set; } = null!;

    public int? Quantity { get; set; }

    public decimal Price { get; set; }

    public string PriceIndicator { get; set; } = null!;

    public decimal? Principal { get; set; }

    public decimal? BrokerCommission { get; set; }

    public string BrokerCommissionInd { get; set; } = null!;

    public decimal Msfees { get; set; }

    public string NotRequired { get; set; } = null!;

    public string MsfeesInd { get; set; } = null!;

    public string DivEntitlPercent { get; set; } = null!;

    public string Spread { get; set; } = null!;

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

    public string FxRate { get; set; } = null!;

    public string AcquisitionDate { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public string SwapReferenceNo { get; set; } = null!;

    public string BasketId { get; set; } = null!;

    public string PriceCurrency { get; set; } = null!;

    public string ResetIndicator { get; set; } = null!;

    public string SnSreference { get; set; } = null!;

    public string ResearchFee { get; set; } = null!;

    public string ResearchFeeInd { get; set; } = null!;

    public string Lei { get; set; } = null!;

    public string MaturityDate { get; set; } = null!;

    public string ProductType { get; set; } = null!;

    public string FuutPartUnwindInd { get; set; } = null!;

    public string PaymentDate { get; set; } = null!;

    public string DividendAmount { get; set; } = null!;

    public string DividendPayoutDate { get; set; } = null!;

    public string NextResetDate { get; set; } = null!;

    public string ResetPrice { get; set; } = null!;

    public string EquitySpread { get; set; } = null!;

    public string DaycountConvention { get; set; } = null!;

    public string FloatingRate { get; set; } = null!;

    public string RollConvention { get; set; } = null!;

    public string CollateralPledge { get; set; } = null!;

    public string FixingFrequency { get; set; } = null!;

    public string PaymentFrequency { get; set; } = null!;
}
