using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class FxemTrade
{
    public string? Header { get; set; }

    public string? TradeId { get; set; }

    public string? DateTime { get; set; }

    public string? Status { get; set; }

    public string? Product { get; set; }

    public string? DealType { get; set; }

    public string? Ccys { get; set; }

    public string? Side { get; set; }

    public string? AmountCcy1 { get; set; }

    public string? Ccy { get; set; }

    public string? AmountCcy2 { get; set; }

    public string? ContraCcy { get; set; }

    public string? TradeDate { get; set; }

    public string? ValueDate { get; set; }

    public string? AllInRate { get; set; }

    public string? SpotRate { get; set; }

    public string? FwdPoints { get; set; }

    public string? DealCode { get; set; }

    public string? Account { get; set; }

    public string? Counterparty { get; set; }

    public string? RebalancingId { get; set; }

    public string? PortfolioId { get; set; }

    public string? PositionSide { get; set; }

    public string? FxemOrderId { get; set; }

    public string? Trader { get; set; }
}
