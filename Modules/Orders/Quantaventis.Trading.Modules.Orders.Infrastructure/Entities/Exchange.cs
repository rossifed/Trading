using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class Exchange
{
    public short ExchangeId { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<ExecutionProfileSelectionRule> ExecutionProfileSelectionRules { get; } = new List<ExecutionProfileSelectionRule>();

    public virtual ICollection<Instrument> Instruments { get; } = new List<Instrument>();
}
