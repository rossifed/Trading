using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class VwOrderHistory
{
    public int OrderId { get; set; }

    public int? RebalancingSessionId { get; set; }

    public int InstrumentId { get; set; }

    public string? Symbol { get; set; }

    public string? Name { get; set; }

    public string? Currency { get; set; }

    public string? Exchange { get; set; }

    public string? MarketSector { get; set; }

    public string? InstrumentType { get; set; }

    public byte OrderSideId { get; set; }

    public string? OrderSide { get; set; }

    public int Quantity { get; set; }

    public int BrokerId { get; set; }

    public string? BrokerCode { get; set; }

    public string? BrokerName { get; set; }

    public int OrderTypeId { get; set; }

    public string? OrderType { get; set; }

    public byte TimeInForceId { get; set; }

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

    public int TradingDeskId { get; set; }

    public string? TradingDesk { get; set; }

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
}
