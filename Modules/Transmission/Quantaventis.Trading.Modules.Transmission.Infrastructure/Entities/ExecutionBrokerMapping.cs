using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class ExecutionBrokerMapping
{
    public string TradeDesk { get; set; } = null!;

    public string ExecutionBroker { get; set; } = null!;
}
