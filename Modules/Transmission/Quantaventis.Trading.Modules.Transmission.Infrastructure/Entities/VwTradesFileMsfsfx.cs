using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class VwTradesFileMsfsfx
{
    public string TrasationType { get; set; } = null!;

    public string TransactionStatus { get; set; } = null!;

    public string TransLevel { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public int ClientTradeRef { get; set; }

    public string AssociatedTradeId { get; set; } = null!;

    public string ExecAccount { get; set; } = null!;

    public string AccountId { get; set; } = null!;

    public string ExecutionBroker { get; set; } = null!;

    public string? TradeDate { get; set; }

    public string? ValueDate { get; set; }

    public decimal? BuyQuantity { get; set; }

    public decimal? SellQuantity { get; set; }

    public string? BuyCcy { get; set; }

    public string? SellCcy { get; set; }

    public string DealtCcy { get; set; } = null!;

    public decimal? Rate { get; set; }

    public string NdfFlag { get; set; } = null!;

    public string NdfFixingDate { get; set; } = null!;

    public string NdfLinkedTrade { get; set; } = null!;

    public string Pb { get; set; } = null!;

    public string FarValueDate { get; set; } = null!;

    public string FarValueRate { get; set; } = null!;

    public string ClientBaseEquivalent { get; set; } = null!;

    public string HedgeOrSpeculative { get; set; } = null!;

    public string TaxIndicator { get; set; } = null!;

    public string HeasayInd { get; set; } = null!;

    public string Custodian { get; set; } = null!;

    public string MoneyManager { get; set; } = null!;

    public string DealId { get; set; } = null!;

    public string AcquisitionDate { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public string TradeType { get; set; } = null!;

    public string Reporter { get; set; } = null!;
}
