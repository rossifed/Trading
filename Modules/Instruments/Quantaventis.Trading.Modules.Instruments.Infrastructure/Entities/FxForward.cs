using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class FxForward
{
    public int FxForwardId { get; set; }

    public int CurrencyPairId { get; set; }

    public DateTime MaturityDate { get; set; }

    public virtual CurrencyPair CurrencyPair { get; set; } = null!;

    public virtual Instrument FxForwardNavigation { get; set; } = null!;
}
