using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class ClearingBrokerCodeMapping
{
    public int FileGenerationTypeId { get; set; }

    public string InternalCode { get; set; } = null!;

    public string CounterpartyCode { get; set; } = null!;

    public virtual FileGenerationType FileGenerationType { get; set; } = null!;
}
