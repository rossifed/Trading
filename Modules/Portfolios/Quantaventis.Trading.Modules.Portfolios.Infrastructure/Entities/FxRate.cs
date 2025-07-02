using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;

public partial class FxRate
{
    public string BaseCurrency { get; set; } = null!;

    public string QuoteCurrency { get; set; } = null!;

    public decimal Value { get; set; }

    public DateTime Date { get; set; }
}
