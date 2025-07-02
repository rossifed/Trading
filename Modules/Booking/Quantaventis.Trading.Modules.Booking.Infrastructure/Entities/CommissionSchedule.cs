using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class CommissionSchedule
{
    public int CommissionScheduleId { get; set; }

    public int InstrumentId { get; set; }

    public int ExecutionBrokerId { get; set; }

    public int CounterpartyRoleSetupId { get; set; }

    public int ExecutionTypeId { get; set; }

    public int CommissionTypeId { get; set; }

    public decimal CommissionValue { get; set; }

    public virtual CommissionType CommissionType { get; set; } = null!;

    public virtual CounterpartyRoleSetup CounterpartyRoleSetup { get; set; } = null!;

    public virtual Counterparty ExecutionBroker { get; set; } = null!;

    public virtual ExecutionType ExecutionType { get; set; } = null!;

    public virtual Instrument Instrument { get; set; } = null!;
}
