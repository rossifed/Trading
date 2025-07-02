using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class BrokerSelectionRule
{
    public int BrokerSelectionRuleId { get; set; }

    public byte? PortfolioId { get; set; }

    public byte? InstrumentTypeId { get; set; }

    public int BrokerId { get; set; }

    public virtual Broker Broker { get; set; } = null!;

    public virtual InstrumentType? InstrumentType { get; set; }

    public virtual Portfolio? Portfolio { get; set; }
}
