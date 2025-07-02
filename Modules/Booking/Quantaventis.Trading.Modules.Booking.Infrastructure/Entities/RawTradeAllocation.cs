using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class RawTradeAllocation
{
    public int TradeAllocationId { get; set; }

    public int TradeId { get; set; }

    public byte PortfolioId { get; set; }

    public int AllocatedQuantity { get; set; }

    public int OrderAllocationQuantity { get; set; }

    public string PositionSide { get; set; } = null!;

    public virtual RawTrade Trade { get; set; } = null!;
}
