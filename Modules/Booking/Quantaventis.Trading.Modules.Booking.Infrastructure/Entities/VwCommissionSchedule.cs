using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class VwCommissionSchedule
{
    public int CommissionScheduleId { get; set; }

    public string? Symbol { get; set; }

    public string? ExecutionBroker { get; set; }

    public string? ClearingBroker { get; set; }

    public string? PrimeBroker { get; set; }

    public string? Custodian { get; set; }

    public string? ExecutionType { get; set; }

    public string? CommissionType { get; set; }

    public decimal CommissionValue { get; set; }
}
