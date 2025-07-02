using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class VwNonAllocatedTrade
{
    public int TradeId { get; set; }

    public string Symbol { get; set; } = null!;

    public DateTime TradeDate { get; set; }
}
