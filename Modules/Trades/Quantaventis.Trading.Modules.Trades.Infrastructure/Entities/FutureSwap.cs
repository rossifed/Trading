using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class FutureSwap
{
    public int GenericFutureId { get; set; }

    public string? SettlementCurrency { get; set; }
}
