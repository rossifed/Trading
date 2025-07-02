using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class VwDailyBookedTrade
{
    public int TradeId { get; set; }

    public string TradeStatus { get; set; } = null!;

    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string TradeSide { get; set; } = null!;

    public int TradeQuantity { get; set; }

    public decimal NominalQuantity { get; set; }

    public string TradeCurrency { get; set; } = null!;

    public DateTime TradeDate { get; set; }

    public string? Exchange { get; set; }

    public string ExecutionChannel { get; set; } = null!;

    public string ExecutionType { get; set; } = null!;

    public bool IsSwap { get; set; }

    public int? RebalancingId { get; set; }

    public decimal ContractMultiplier { get; set; }

    public decimal PriceScalingFactor { get; set; }

    public decimal AvgPrice { get; set; }

    public decimal Principal { get; set; }

    public decimal TradeValue { get; set; }

    public string InstrumentType { get; set; } = null!;

    public string TradeInstrumentType { get; set; } = null!;

    public string ExecutionDesk { get; set; } = null!;

    public string ExecutionBroker { get; set; } = null!;

    public string ExecutionAccount { get; set; } = null!;

    public string? Isin { get; set; }

    public string? Sedol { get; set; }

    public string? Cusip { get; set; }

    public string? SecurityName { get; set; }

    public string? LocalExchangeSymbol { get; set; }

    public DateTime? SettlementDate { get; set; }

    public int? EmsxOrderId { get; set; }

    public int? OrderReferenceId { get; set; }

    public int? OrderQuantity { get; set; }

    public string? OrderType { get; set; }

    public string? StrategyType { get; set; }

    public string? TimeInForce { get; set; }

    public string? OrderExecutionInstruction { get; set; }

    public string? OrderHandlingInstruction { get; set; }

    public string? OrderInstruction { get; set; }

    public decimal? LimitPrice { get; set; }

    public decimal? StopPrice { get; set; }

    public int? OriginatingTraderUuid { get; set; }

    public string? TraderName { get; set; }

    public int? TraderUuid { get; set; }

    public decimal? UserCommissionAmount { get; set; }

    public decimal? UserCommissionRate { get; set; }

    public decimal? UserFees { get; set; }

    public decimal? UserNetMoney { get; set; }

    public string? YellowKey { get; set; }

    public byte? NumberOfFills { get; set; }

    public DateTime? FirstFillTimeUtc { get; set; }

    public DateTime? LastFillTimeUtc { get; set; }

    public decimal? MaxFillPrice { get; set; }

    public decimal? MinFillPrice { get; set; }

    public DateTime BookedOnUtc { get; set; }

    public DateTime? LastCorrectedOnUtc { get; set; }

    public DateTime? CanceledOnUtc { get; set; }
}
