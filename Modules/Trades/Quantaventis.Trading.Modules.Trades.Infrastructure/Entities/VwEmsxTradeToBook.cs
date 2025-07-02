using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class VwEmsxTradeToBook
{
    public int? TradeId { get; set; }

    public int EmsxSequence { get; set; }

    public int? OrderId { get; set; }

    public int? RebalancingId { get; set; }

    public string? EmsxOrderRefId { get; set; }

    public DateTime? EmsxDate { get; set; }

    public int? InstrumentId { get; set; }

    public string? Symbol { get; set; }

    public string? Side { get; set; }

    public string? PositionSide { get; set; }

    public int? OrderQuantity { get; set; }

    public int? FilledQuantity { get; set; }

    public string? ExchangeCode { get; set; }

    public string? Sedol { get; set; }

    public string Account { get; set; } = null!;

    public decimal? TotalCharges { get; set; }

    public DateTime? TradeDate { get; set; }

    public decimal? Principal { get; set; }

    public decimal? NetAmount { get; set; }

    public byte? PortfolioId { get; set; }

    public decimal AvgPrice { get; set; }

    public decimal? DayAvgPrice { get; set; }

    public string? TradeCurrency { get; set; }

    public string? OrderType { get; set; }

    public string? TimeInForce { get; set; }

    public string? Strategy { get; set; }

    public string HandInstruction { get; set; } = null!;

    public DateTime? SettleDate { get; set; }

    public string? SettleCurrency { get; set; }

    public decimal? BrokerCommm { get; set; }

    public decimal? CommmRate { get; set; }

    public decimal? MiscFees { get; set; }

    public string? Notes { get; set; }

    public string? Trader { get; set; }

    public string Broker { get; set; } = null!;

    public int IsCfd { get; set; }

    public int IsFutureSwap { get; set; }

    public string ExecutionChannel { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public int IsInstrumentMapped { get; set; }

    public int IsTradeAlreadyBooked { get; set; }

    public decimal? CommPerLot { get; set; }

    public decimal? CommRate { get; set; }
}
