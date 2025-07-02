using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class MarketDatum
{
    public int InstrumentId { get; set; }

    public decimal LastPrice { get; set; }

    public decimal LastPriceEod { get; set; }

    public decimal? VolumeAvg30Day { get; set; }

    public decimal? MarketCap { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public DateTime LastUpdateDateEod { get; set; }

    public TimeSpan? LastUpdateTime { get; set; }

    public string Currency { get; set; } = null!;

    public virtual Instrument Instrument { get; set; } = null!;
}
