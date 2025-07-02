using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class VwExecutionProfile
{
    public int ExecutionProfileId { get; set; }

    public int OrderTypeId { get; set; }

    public string? OrderType { get; set; }

    public byte TimeInForceId { get; set; }

    public string? TimeInForce { get; set; }

    public int ExecutionAlgorithmId { get; set; }

    public string? ExecutionAlgorithm { get; set; }

    public int HandlingInstructionId { get; set; }

    public string? HandlingInstruction { get; set; }

    public byte ExecutionChannelId { get; set; }

    public string? ExecutionChannel { get; set; }

    public int TradingDeskId { get; set; }

    public string? TradingDesk { get; set; }

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
