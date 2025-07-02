using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class ExecutionProfile
{
    public int ExecutionProfileId { get; set; }

    public int OrderTypeId { get; set; }

    public byte TimeInForceId { get; set; }

    public int ExecutionAlgorithmId { get; set; }

    public int? ExecutionAlgorithmParamSetId { get; set; }

    public int HandlingInstructionId { get; set; }

    public byte ExecutionChannelId { get; set; }

    public int TradingDeskId { get; set; }

    public virtual ExecutionAlgorithm ExecutionAlgorithm { get; set; } = null!;

    public virtual ExecutionAlgorithmParamSet? ExecutionAlgorithmParamSet { get; set; }

    public virtual ExecutionChannel ExecutionChannel { get; set; } = null!;

    public virtual ICollection<ExecutionProfileSelectionRuleOverride> ExecutionProfileSelectionRuleOverrides { get; } = new List<ExecutionProfileSelectionRuleOverride>();

    public virtual ICollection<ExecutionProfileSelectionRule> ExecutionProfileSelectionRules { get; } = new List<ExecutionProfileSelectionRule>();

    public virtual HandlingInstruction HandlingInstruction { get; set; } = null!;

    public virtual OrderType OrderType { get; set; } = null!;

    public virtual TimeInForce TimeInForce { get; set; } = null!;

    public virtual TradingDesk TradingDesk { get; set; } = null!;
}
