using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int? RebalancingSessionId { get; set; }

    public int InstrumentId { get; set; }

    public byte OrderSideId { get; set; }

    public int Quantity { get; set; }

    public int BrokerId { get; set; }

    public int OrderTypeId { get; set; }

    public byte TimeInForceId { get; set; }

    public int ExecutionAlgorithmId { get; set; }

    public int HandlingInstructionId { get; set; }

    public byte ExecutionChannelId { get; set; }

    public byte TradeModeId { get; set; }

    public DateTime TradeDate { get; set; }

    public int TradingDeskId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? Param1 { get; set; }

    public string? Value1 { get; set; }

    public string? Param2 { get; set; }

    public string? Value2 { get; set; }

    public string? Param3 { get; set; }

    public string? Value3 { get; set; }

    public string? Param4 { get; set; }

    public string? Value4 { get; set; }

    public string? Param5 { get; set; }

    public string? Value5 { get; set; }

    public string? Param6 { get; set; }

    public string? Value6 { get; set; }

    public string? Param7 { get; set; }

    public string? Value7 { get; set; }

    public string? Param8 { get; set; }

    public string? Value8 { get; set; }

    public string? OrderRef { get; set; }

    public string OrderReason { get; set; } = null!;

    public virtual Broker Broker { get; set; } = null!;

    public virtual ExecutionAlgorithm ExecutionAlgorithm { get; set; } = null!;

    public virtual ExecutionChannel ExecutionChannel { get; set; } = null!;

    public virtual HandlingInstruction HandlingInstruction { get; set; } = null!;

    public virtual Instrument Instrument { get; set; } = null!;

    public virtual ICollection<OrderAllocation> OrderAllocations { get; } = new List<OrderAllocation>();

    public virtual OrderSide OrderSide { get; set; } = null!;

    public virtual OrderType OrderType { get; set; } = null!;

    public virtual TimeInForce TimeInForce { get; set; } = null!;

    public virtual TradeMode TradeMode { get; set; } = null!;

    public virtual TradingDesk TradingDesk { get; set; } = null!;
}
