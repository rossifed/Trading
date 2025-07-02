using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class VwTradeAllocation
{
    public int TradeAllocationId { get; set; }

    public int TradeId { get; set; }

    public int? OrderId { get; set; }

    public int? RebalancingId { get; set; }

    public int? EmsxSequence { get; set; }

    public DateTime? EmsxOrderCreatedOn { get; set; }

    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string? ExchangeCode { get; set; }

    public string? Sedol { get; set; }

    public string BuySellIndicator { get; set; } = null!;

    public int OrderQuantity { get; set; }

    public int FilledQuantity { get; set; }

    public decimal AvgPrice { get; set; }

    public decimal? DayAveragePrice { get; set; }

    public string TradeCurrency { get; set; } = null!;

    public DateTime TradeDate { get; set; }

    public decimal Principal { get; set; }

    public decimal NetAmount { get; set; }

    public DateTime? SettlementDate { get; set; }

    public string? SettlementCurrency { get; set; }

    public decimal BrokerCommission { get; set; }

    public decimal CommissionRate { get; set; }

    public decimal MiscFees { get; set; }

    public string? Notes { get; set; }

    public string? Trader { get; set; }

    public string BrokerCode { get; set; } = null!;

    public string TradeDesk { get; set; } = null!;

    public bool IsCfd { get; set; }

    public string? ExecutionChannel { get; set; }

    public DateTime? CreatedOn { get; set; }

    public decimal TotalCharges { get; set; }

    public int? FxemTradeId { get; set; }

    public int? FxemOrderId { get; set; }

    public string TradeStatus { get; set; } = null!;

    public string? FxCurrency1 { get; set; }

    public decimal? Fxcurrency1Amount { get; set; }

    public string? FxCurrency2 { get; set; }

    public decimal? Fxcurrency2Amount { get; set; }

    public DateTime BookedOn { get; set; }

    public byte PortfolioId { get; set; }

    public int AllocationQuantity { get; set; }

    public decimal Price { get; set; }

    public decimal AllocationGrossAmount { get; set; }

    public decimal AllocationNetAmount { get; set; }

    public decimal AllocationCommission { get; set; }

    public decimal AllocationFees { get; set; }

    public string? PositionSide { get; set; }

    public string TradingAccount { get; set; } = null!;
}
