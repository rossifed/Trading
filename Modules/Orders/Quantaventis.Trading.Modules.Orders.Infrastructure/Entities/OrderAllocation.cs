using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class OrderAllocation
{
    public int OrderAllocationId { get; set; }

    public int OrderId { get; set; }

    public byte PortfolioId { get; set; }

    public int Quantity { get; set; }

    public int TradingAccountId { get; set; }

    public byte PositionSideId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;

    public virtual PositionSide PositionSide { get; set; } = null!;

    public virtual TradingAccount TradingAccount { get; set; } = null!;
}
