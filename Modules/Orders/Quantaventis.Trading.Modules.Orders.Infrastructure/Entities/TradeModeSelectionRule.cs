using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class TradeModeSelectionRule
{
    public int TradeModeSelectionRuleId { get; set; }

    public byte? PortfolioId { get; set; }

    public int? BrokerId { get; set; }

    public byte? InstrumentTypeId { get; set; }

    public bool? IsEfrp { get; set; }

    public byte TradeModeId { get; set; }

    public virtual Broker? Broker { get; set; }

    public virtual InstrumentType? InstrumentType { get; set; }

    public virtual Portfolio? Portfolio { get; set; }

    public virtual TradeMode TradeMode { get; set; } = null!;
}
