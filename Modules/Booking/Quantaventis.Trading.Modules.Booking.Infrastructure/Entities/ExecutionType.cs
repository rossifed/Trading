using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class ExecutionType
{
    public int ExecutionTypeId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<CommissionSchedule> CommissionSchedules { get; } = new List<CommissionSchedule>();

    public virtual ICollection<ExecutionTypeMapping> ExecutionTypeMappings { get; } = new List<ExecutionTypeMapping>();
}
