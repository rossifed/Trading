using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class ExecutionDesk
{
    public int ExecutionDeskId { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public int ExecutionBrokerId { get; set; }

    public virtual Counterparty ExecutionBroker { get; set; } = null!;

    public virtual ICollection<ExecutionTypeMapping> ExecutionTypeMappings { get; } = new List<ExecutionTypeMapping>();
}
