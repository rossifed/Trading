using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class TradeMode
{
    public byte TradeModeId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<ExecutionProfileSelectionRuleOverride> ExecutionProfileSelectionRuleOverrides { get; } = new List<ExecutionProfileSelectionRuleOverride>();

    public virtual ICollection<ExecutionProfileSelectionRule> ExecutionProfileSelectionRules { get; } = new List<ExecutionProfileSelectionRule>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<TradeModeSelectionRule> TradeModeSelectionRules { get; } = new List<TradeModeSelectionRule>();

    public virtual ICollection<TradingAccountSelectionRule> TradingAccountSelectionRules { get; } = new List<TradingAccountSelectionRule>();
}
