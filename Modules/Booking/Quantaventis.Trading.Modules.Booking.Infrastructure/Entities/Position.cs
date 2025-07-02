using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class Position
{
    public byte PortfolioId { get; set; }

    public int InstrumentId { get; set; }

    public int Quantity { get; set; }

    public bool IsSwap { get; set; }

    public DateTime PositionDate { get; set; }

    public virtual Instrument Instrument { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;
}
