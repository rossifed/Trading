using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class OrderAllocation
{
    public int OrderId { get; set; }

    public byte PortfolioId { get; set; }

    public int Quantity { get; set; }

    public string PositionSide { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
