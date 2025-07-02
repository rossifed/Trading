using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class vwLastFxRateEod
{
    public string BaseCurrency { get; set; } = null!;

    public string QuoteCurrency { get; set; } = null!;

    public DateTime LastUpdateDateEod { get; set; }

    public decimal LastValueEod { get; set; }
}
