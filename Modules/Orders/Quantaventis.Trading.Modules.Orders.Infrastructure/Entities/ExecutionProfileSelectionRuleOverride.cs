using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class ExecutionProfileSelectionRuleOverride
{
    public int ExecutionProfileSelectionRuleOverrideId { get; set; }

    public byte PortfolioId { get; set; }

    public int BrokerId { get; set; }

    public int InstrumentId { get; set; }

    public byte TradeModeId { get; set; }

    public int ExecutionProfileId { get; set; }

    public virtual Broker Broker { get; set; } = null!;

    public virtual ExecutionProfile ExecutionProfile { get; set; } = null!;

    public virtual Instrument Instrument { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;

    public virtual TradeMode TradeMode { get; set; } = null!;
}
