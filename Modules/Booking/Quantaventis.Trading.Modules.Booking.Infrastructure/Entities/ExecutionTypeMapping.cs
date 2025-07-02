using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class ExecutionTypeMapping
{
    public int ExecutionDeskId { get; set; }

    public string Strategy { get; set; } = null!;

    public int ExecutionTypeId { get; set; }

    public virtual ExecutionDesk ExecutionDesk { get; set; } = null!;

    public virtual ExecutionType ExecutionType { get; set; } = null!;
}
