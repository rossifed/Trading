using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class VwFxemTradeToBook
{
    public string? FxemOrderId { get; set; }

    public int? RebalancingId { get; set; }

    public int? EmsxSequence { get; set; }

    public DateTime? EmsxOrderCreatedOn { get; set; }

    public int? InstrumentId { get; set; }

    public int? ExchangeCode { get; set; }

    public int? Sedol { get; set; }

    public string? BuySellIndicator { get; set; }

    public decimal? OrderQuantity { get; set; }

    public decimal? FilledQuantity { get; set; }

    public decimal? AvgPrice { get; set; }

    public int? DayAveragePrice { get; set; }

    public string? TradeCurrency { get; set; }

    public DateTime? TradeDate { get; set; }

    public decimal? Principal { get; set; }

    public decimal? NetAmount { get; set; }

    public DateTime? SettlementDate { get; set; }

    public int? SettlementCurrency { get; set; }

    public int BrokerCommission { get; set; }

    public int CommissionRate { get; set; }

    public int MiscFees { get; set; }

    public int? Notes { get; set; }

    public string? Trader { get; set; }

    public string? BrokerCode { get; set; }

    public string? TradeDesk { get; set; }

    public int IsCfd { get; set; }

    public string ExecutionChannel { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public int TotalCharges { get; set; }

    public string? Account { get; set; }

    public string? FxemTradeId { get; set; }

    public string? Ccy1 { get; set; }

    public decimal? AmountCcy1 { get; set; }

    public string? Ccy2 { get; set; }

    public decimal? AmountCcy2 { get; set; }

    public int? PortfolioId { get; set; }

    public string? PositionSide { get; set; }
}
