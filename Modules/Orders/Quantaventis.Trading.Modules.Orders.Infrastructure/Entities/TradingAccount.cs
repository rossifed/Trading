using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class TradingAccount
{
    public int TradingAccountId { get; set; }

    public string Code { get; set; } = null!;

    public int BrokerId { get; set; }

    public virtual ICollection<OrderAllocation> OrderAllocations { get; } = new List<OrderAllocation>();

    public virtual ICollection<TradingAccountSelectionRule> TradingAccountSelectionRules { get; } = new List<TradingAccountSelectionRule>();
}
