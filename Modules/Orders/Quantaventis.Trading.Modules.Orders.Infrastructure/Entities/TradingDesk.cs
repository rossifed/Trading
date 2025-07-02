using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class TradingDesk
{
    public int TradingDeskId { get; set; }

    public int BrokerId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual Broker Broker { get; set; } = null!;

    public virtual ICollection<ExecutionProfile> ExecutionProfiles { get; } = new List<ExecutionProfile>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
