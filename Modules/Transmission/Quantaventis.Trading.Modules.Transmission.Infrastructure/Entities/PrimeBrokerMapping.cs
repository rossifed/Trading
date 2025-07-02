using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class PrimeBrokerMapping
{
    public string ExecutionBroker { get; set; } = null!;

    public byte PortfolioId { get; set; }

    public string InstrumentType { get; set; } = null!;

    public bool IsSwap { get; set; }

    public string PrimeBroker { get; set; } = null!;
}
