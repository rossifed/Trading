using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class CommissionType
{
    public int CommissionTypeId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<CommissionSchedule> CommissionSchedules { get; } = new List<CommissionSchedule>();
}
