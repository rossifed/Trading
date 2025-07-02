using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class PrimeBrokerCodeMapping
{
    public string FileGenerationType { get; set; } = null!;

    public string InternalCode { get; set; } = null!;

    public string CounterpartyCode { get; set; } = null!;
}
