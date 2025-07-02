using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class ClearingAccountCodeMapping
{
    public int CounterpartyId { get; set; }

    public string InternalCode { get; set; } = null!;

    public string CounterpartyCode { get; set; } = null!;

    public virtual Counterparty Counterparty { get; set; } = null!;
}
