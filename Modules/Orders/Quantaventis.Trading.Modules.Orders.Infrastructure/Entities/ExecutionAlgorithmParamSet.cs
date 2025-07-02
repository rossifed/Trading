using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class ExecutionAlgorithmParamSet
{
    public int ExecutionAlgorithmParamSetId { get; set; }

    public int ExecutionAlgorithmId { get; set; }

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

    public virtual ExecutionAlgorithm ExecutionAlgorithm { get; set; } = null!;

    public virtual ICollection<ExecutionProfile> ExecutionProfiles { get; } = new List<ExecutionProfile>();
}
