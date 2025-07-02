using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class FxForward
{
    public int FxForwardId { get; set; }

    public string Symbol { get; set; } = null!;

    public int CurrencyPairId { get; set; }

    public DateTime MaturityDate { get; set; }
}
