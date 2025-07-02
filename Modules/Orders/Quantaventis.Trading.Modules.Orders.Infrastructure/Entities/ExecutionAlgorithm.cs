using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class ExecutionAlgorithm
{
    public int ExecutionAlgorithmId { get; set; }

    public string Mnmemonic { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<ExecutionAlgorithmParamSet> ExecutionAlgorithmParamSets { get; } = new List<ExecutionAlgorithmParamSet>();

    public virtual ICollection<ExecutionProfile> ExecutionProfiles { get; } = new List<ExecutionProfile>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
