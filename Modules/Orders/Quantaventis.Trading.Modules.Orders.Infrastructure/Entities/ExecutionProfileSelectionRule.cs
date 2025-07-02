using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class ExecutionProfileSelectionRule
{
    public int ExecutionProfileSelectionRuleId { get; set; }

    public byte? PortfolioId { get; set; }

    public int? BrokerId { get; set; }

    public byte? InstrumentTypeId { get; set; }

    public byte TradeModeId { get; set; }

    public short? ExchangeId { get; set; }

    public int ExecutionProfileId { get; set; }

    public virtual Broker? Broker { get; set; }

    public virtual Exchange? Exchange { get; set; }

    public virtual ExecutionProfile ExecutionProfile { get; set; } = null!;

    public virtual InstrumentType? InstrumentType { get; set; }

    public virtual Portfolio? Portfolio { get; set; }

    public virtual TradeMode TradeMode { get; set; } = null!;
}
