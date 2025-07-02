using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class Broker
{
    public int BrokerId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<BrokerSelectionRuleOverride> BrokerSelectionRuleOverrides { get; } = new List<BrokerSelectionRuleOverride>();

    public virtual ICollection<BrokerSelectionRule> BrokerSelectionRules { get; } = new List<BrokerSelectionRule>();

    public virtual ICollection<ExecutionProfileSelectionRuleOverride> ExecutionProfileSelectionRuleOverrides { get; } = new List<ExecutionProfileSelectionRuleOverride>();

    public virtual ICollection<ExecutionProfileSelectionRule> ExecutionProfileSelectionRules { get; } = new List<ExecutionProfileSelectionRule>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<TradeModeSelectionRule> TradeModeSelectionRules { get; } = new List<TradeModeSelectionRule>();

    public virtual ICollection<TradingAccountSelectionRule> TradingAccountSelectionRules { get; } = new List<TradingAccountSelectionRule>();

    public virtual ICollection<TradingDesk> TradingDesks { get; } = new List<TradingDesk>();
}
