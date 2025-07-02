using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class RawTrade
{
    public int TradeId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Side { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal AvgPrice { get; set; }

    public string Currency { get; set; } = null!;

    public DateTime TradeDate { get; set; }

    public string? Exchange { get; set; }

    public string ExecutionBroker { get; set; } = null!;

    public string ExecutionAccount { get; set; } = null!;

    public string ExecutionDesk { get; set; } = null!;

    public bool IsCfd { get; set; }

    public string? Cusip { get; set; }

    public string? Isin { get; set; }

    public string? Sedol { get; set; }

    public string? SecurityName { get; set; }

    public string? LocalExchangeSymbol { get; set; }

    public string ExecutionChannel { get; set; } = null!;

    public int? EmsxOrderId { get; set; }

    public int? OrderReferenceId { get; set; }

    public int? OrderQuantity { get; set; }

    public string? OrderType { get; set; }

    public string? StrategyType { get; set; }

    public string? Tif { get; set; }

    public string? OrderExecutionInstruction { get; set; }

    public string? OrderHandlingInstruction { get; set; }

    public string? OrderInstruction { get; set; }

    public decimal? LimitPrice { get; set; }

    public decimal? StopPrice { get; set; }

    public int? OriginatingTraderUuid { get; set; }

    public string? TraderName { get; set; }

    public int? TraderUuid { get; set; }

    public DateTime? SettlementDate { get; set; }

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

    public virtual ICollection<RawTradeAllocation> RawTradeAllocations { get; } = new List<RawTradeAllocation>();

    public virtual ICollection<TradeBookingError> TradeBookingErrors { get; } = new List<TradeBookingError>();
}
