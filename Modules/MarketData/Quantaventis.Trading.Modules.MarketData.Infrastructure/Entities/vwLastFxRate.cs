using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class vwLastFxRate
{
    public string BaseCurrency { get; set; } = null!;

    public string QuoteCurrency { get; set; } = null!;

    public DateTime LastUpdateDate { get; set; }

    public decimal LastValue { get; set; }
}
