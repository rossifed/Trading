using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class Counterparty
{
    public int CounterpartyId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool IsExecutionBroker { get; set; }

    public bool IsClearingBroker { get; set; }

    public bool IsPrimeBroker { get; set; }

    public bool IsCustodian { get; set; }

    public virtual ICollection<ClearingAccount> ClearingAccounts { get; } = new List<ClearingAccount>();

    public virtual ICollection<CommissionSchedule> CommissionSchedules { get; } = new List<CommissionSchedule>();

    public virtual ICollection<CounterpartyRoleAssignment> CounterpartyRoleAssignments { get; } = new List<CounterpartyRoleAssignment>();

    public virtual ICollection<CounterpartyRoleSetup> CounterpartyRoleSetupClearingBrokers { get; } = new List<CounterpartyRoleSetup>();

    public virtual ICollection<CounterpartyRoleSetup> CounterpartyRoleSetupCustodians { get; } = new List<CounterpartyRoleSetup>();

    public virtual ICollection<CounterpartyRoleSetup> CounterpartyRoleSetupPrimeBrokers { get; } = new List<CounterpartyRoleSetup>();

    public virtual ICollection<ExecutionDesk> ExecutionDesks { get; } = new List<ExecutionDesk>();

    public virtual ICollection<FutureSwap> FutureSwaps { get; } = new List<FutureSwap>();

    public virtual ICollection<SettlementInfo> SettlementInfos { get; } = new List<SettlementInfo>();
}
