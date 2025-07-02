using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class FxRate
{
    public string BaseCurrency { get; set; } = null!;

    public string QuoteCurrency { get; set; } = null!;

    public decimal LastValue { get; set; }

    public decimal LastValueEod { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public DateTime LastUpdateDateEod { get; set; }

    public TimeSpan? LastUpdateTime { get; set; }
}
