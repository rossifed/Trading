using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class vwLastPriceEod
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public decimal LastPriceEod { get; set; }

    public DateTime LastUpdateDateEod { get; set; }

    public string Currency { get; set; } = null!;
}
