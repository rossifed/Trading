using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class TradingAccountSelectionRule
{
    public int TradingAccountSelectionRuleId { get; set; }

    public byte PortfolioId { get; set; }

    public int BrokerId { get; set; }

    public byte InstrumentTypeId { get; set; }

    public byte TradeModeId { get; set; }

    public int TradingAccountId { get; set; }

    public virtual Broker Broker { get; set; } = null!;

    public virtual InstrumentType InstrumentType { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;

    public virtual TradeMode TradeMode { get; set; } = null!;

    public virtual TradingAccount TradingAccount { get; set; } = null!;
}
