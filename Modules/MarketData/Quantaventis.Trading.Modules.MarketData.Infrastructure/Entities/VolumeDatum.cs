using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class VolumeDatum
{
    public int InstrumentId { get; set; }

    public decimal? Volume1Day { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public TimeSpan? LastUpdateTime { get; set; }

    public virtual Instrument Instrument { get; set; } = null!;
}
