using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class VwFutureSwap
{
    public int? GenericFutureId { get; set; }

    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string? SettlementCurrency { get; set; }
}
