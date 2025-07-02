using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class InstrumentType
{
    public byte InstrumentTypeId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<BrokerSelectionRule> BrokerSelectionRules { get; } = new List<BrokerSelectionRule>();

    public virtual ICollection<ExecutionProfileSelectionRule> ExecutionProfileSelectionRules { get; } = new List<ExecutionProfileSelectionRule>();

    public virtual ICollection<Instrument> Instruments { get; } = new List<Instrument>();

    public virtual ICollection<TradeModeSelectionRule> TradeModeSelectionRules { get; } = new List<TradeModeSelectionRule>();

    public virtual ICollection<TradingAccountSelectionRule> TradingAccountSelectionRules { get; } = new List<TradingAccountSelectionRule>();
}
