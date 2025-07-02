using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public byte InstrumentTypeId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public string? Exchange { get; set; }

    public string MarketSector { get; set; } = null!;

    public short? ExchangeId { get; set; }

    public DateTime? Maturity { get; set; }

    public int? GenericFutureId { get; set; }

    public virtual ICollection<BrokerSelectionRuleOverride> BrokerSelectionRuleOverrides { get; } = new List<BrokerSelectionRuleOverride>();

    public virtual Exchange? ExchangeNavigation { get; set; }

    public virtual ICollection<ExecutionProfileSelectionRuleOverride> ExecutionProfileSelectionRuleOverrides { get; } = new List<ExecutionProfileSelectionRuleOverride>();

    public virtual InstrumentType InstrumentType { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
