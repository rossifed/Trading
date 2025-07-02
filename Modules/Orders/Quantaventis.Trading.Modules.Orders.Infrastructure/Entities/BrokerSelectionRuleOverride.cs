using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class BrokerSelectionRuleOverride
{
    public int BrokerSelectionRuleOverrideId { get; set; }

    public byte PortfolioId { get; set; }

    public int InstrumentId { get; set; }

    public int BrokerId { get; set; }

    public virtual Broker Broker { get; set; } = null!;

    public virtual Instrument Instrument { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;
}
