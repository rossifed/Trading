using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class HandlingInstruction
{
    public int HandlingInstructionId { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<ExecutionProfile> ExecutionProfiles { get; } = new List<ExecutionProfile>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
