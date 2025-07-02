using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class Counterparty
{
    public int CounterpartyId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ClearingAccountCodeMapping> ClearingAccountCodeMappings { get; } = new List<ClearingAccountCodeMapping>();

    public virtual ICollection<ExecutionAccountCodeMapping> ExecutionAccountCodeMappings { get; } = new List<ExecutionAccountCodeMapping>();

    public virtual ICollection<TransmissionProfile> TransmissionProfiles { get; } = new List<TransmissionProfile>();
}
