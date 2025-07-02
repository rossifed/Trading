using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class VwEfrpTradeToBook
{
    public int? TradeId { get; set; }

    public int? EmsxSequence { get; set; }

    public int? OrderId { get; set; }

    public int? RebalancingId { get; set; }

    public int? EmsxDate { get; set; }

    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string? Side { get; set; }

    public string? PositionSide { get; set; }

    public double? OrderQuantity { get; set; }

    public double? FilledQuantity { get; set; }

    public string ExchangeCode { get; set; } = null!;

    public int? Sedol { get; set; }

    public string? Account { get; set; }

    public double? TotalCharges { get; set; }

    public DateTime? TradeDate { get; set; }

    public double? Principal { get; set; }

    public double? NetAmount { get; set; }

    public byte? PortfolioId { get; set; }

    public double? AvgPrice { get; set; }

    public int? DayAvgPrice { get; set; }

    public string TradeCurrency { get; set; } = null!;

    public int? OrderType { get; set; }

    public int? TimeInForce { get; set; }

    public int? Strategy { get; set; }

    public int? HandlingInstruction { get; set; }

    public DateTime? SettlementDate { get; set; }

    public string SettlementCurrency { get; set; } = null!;

    public double? BrokerCommission { get; set; }

    public decimal? CommissionRate { get; set; }

    public int MiscFees { get; set; }

    public string Notes { get; set; } = null!;

    public int? Trader { get; set; }

    public string BrokerCode { get; set; } = null!;

    public string TradeDesk { get; set; } = null!;

    public int IsCfd { get; set; }

    public string ExecutionChannel { get; set; } = null!;

    public int? CreatedOn { get; set; }

    public int IsInstrumentMapped { get; set; }

    public int IsTradeAlreadyBooked { get; set; }
}
