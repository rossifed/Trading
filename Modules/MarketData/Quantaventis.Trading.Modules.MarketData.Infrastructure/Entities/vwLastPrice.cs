using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class vwLastPrice
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public decimal LastPrice { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public TimeSpan? LastUpdateTime { get; set; }

    public string Currency { get; set; } = null!;

    public string QuoteCurrency { get; set; } = null!;

    public decimal QuoteFactor { get; set; }

    public decimal PriceScalingFactor { get; set; }
}
