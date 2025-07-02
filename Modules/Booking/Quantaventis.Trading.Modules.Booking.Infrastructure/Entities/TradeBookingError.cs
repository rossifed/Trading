using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class TradeBookingError
{
    public int TradeBookingErrorId { get; set; }

    public int TradeId { get; set; }

    public string ErrorType { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public virtual RawTrade Trade { get; set; } = null!;
}
