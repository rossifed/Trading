using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class FutureSwap
{
    public int ExecutionBrokerId { get; set; }

    public int GenericFutureId { get; set; }

    public virtual Counterparty ExecutionBroker { get; set; } = null!;
}
