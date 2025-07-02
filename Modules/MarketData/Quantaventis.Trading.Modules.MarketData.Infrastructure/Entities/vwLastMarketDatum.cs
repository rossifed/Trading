using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class vwLastMarketDatum
{
    public int InstrumentId { get; set; }

    public decimal? Open { get; set; }

    public decimal? High { get; set; }

    public decimal? Low { get; set; }

    public decimal LastPrice { get; set; }

    public decimal LastPriceEod { get; set; }

    public decimal? Volume { get; set; }

    public decimal? VolumeAvg30Day { get; set; }

    public decimal? VolumeAvg3Month { get; set; }

    public decimal? VolumeAvg6Month { get; set; }

    public decimal? OpenInterest { get; set; }

    public decimal? MarketCap { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public DateTime LastUpdateDateEod { get; set; }

    public TimeSpan? LastUpdateTime { get; set; }

    public string Currency { get; set; } = null!;
}
