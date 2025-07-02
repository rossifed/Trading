using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class CounterpartyCodeMapping
{
    public int CounterpartyCodeMappingId { get; set; }

    public byte PortfolioId { get; set; }

    public string FileGenerationType { get; set; } = null!;

    public string? ExecutionAccount { get; set; }

    public string? ClearingAccount { get; set; }

    public string? ExecutionBroker { get; set; }

    public string? ClearingBroker { get; set; }

    public string? Custodian { get; set; }
}
