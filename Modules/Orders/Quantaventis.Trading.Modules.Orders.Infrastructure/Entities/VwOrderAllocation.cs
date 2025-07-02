using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class VwOrderAllocation
{
    public int OrderAllocationId { get; set; }

    public int OrderId { get; set; }

    public int? RebalancingSessionId { get; set; }

    public int InstrumentId { get; set; }

    public string? Symbol { get; set; }

    public string? InstrumentName { get; set; }

    public string? Currency { get; set; }

    public string? Exchange { get; set; }

    public string? MarketSector { get; set; }

    public string? InstrumentType { get; set; }

    public string? OrderSide { get; set; }

    public int OrderQuantity { get; set; }

    public string? BrokerCode { get; set; }

    public string? BrokerName { get; set; }

    public string? OrderType { get; set; }

    public string? TimeInForce { get; set; }

    public int ExecutionAlgorithmId { get; set; }

    public string? ExecutionAlgo { get; set; }

    public int HandlingInstructionId { get; set; }

    public string? HandlingInstruction { get; set; }

    public byte ExecutionChannelId { get; set; }

    public string? ExecutionChannel { get; set; }

    public byte TradeModeId { get; set; }

    public string? TradeMode { get; set; }

    public DateTime TradeDate { get; set; }

    public string? TradingDesk { get; set; }

    public byte PortfolioId { get; set; }

    public string PortfolioCurrency { get; set; } = null!;

    public string PotfolioName { get; set; } = null!;

    public string PotfolioMnemonic { get; set; } = null!;

    public int AllocationQuantity { get; set; }

    public int TradingAccountId { get; set; }

    public string TradingAccountCode { get; set; } = null!;

    public byte PositionSideId { get; set; }

    public string PositionSide { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }
}
