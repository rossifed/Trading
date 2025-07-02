using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class InstrumentPricing
{
    public int InstrumentId { get; set; }

    public decimal Price { get; set; }

    public string Currency { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual Instrument Instrument { get; set; } = null!;
}
