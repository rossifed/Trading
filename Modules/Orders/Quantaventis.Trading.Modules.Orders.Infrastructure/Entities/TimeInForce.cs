using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class TimeInForce
{
    public byte TimeInForceId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<ExecutionProfile> ExecutionProfiles { get; } = new List<ExecutionProfile>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
