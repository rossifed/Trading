using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class CounterpartyRoleAssignment
{
    public int CounterpartyRoleAssignmentId { get; set; }

    public int PortfolioId { get; set; }

    public int InstrumentId { get; set; }

    public int ExecutionBrokerId { get; set; }

    public int CounterpartyRoleSetupId { get; set; }

    public virtual CounterpartyRoleSetup CounterpartyRoleSetup { get; set; } = null!;

    public virtual Counterparty ExecutionBroker { get; set; } = null!;

    public virtual Instrument Instrument { get; set; } = null!;
}
