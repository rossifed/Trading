using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class CounterpartyRoleSetup
{
    public int CounterpartyRoleSetupId { get; set; }

    public int ClearingBrokerId { get; set; }

    public int? PrimeBrokerId { get; set; }

    public int? CustodianId { get; set; }

    public virtual Counterparty ClearingBroker { get; set; } = null!;

    public virtual ICollection<CommissionSchedule> CommissionSchedules { get; } = new List<CommissionSchedule>();

    public virtual ICollection<CounterpartyRoleAssignment> CounterpartyRoleAssignments { get; } = new List<CounterpartyRoleAssignment>();

    public virtual Counterparty? Custodian { get; set; }

    public virtual Counterparty? PrimeBroker { get; set; }
}
