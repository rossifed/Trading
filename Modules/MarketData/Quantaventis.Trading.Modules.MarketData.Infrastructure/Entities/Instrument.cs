using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string? Exchange { get; set; }

    public string QuoteCurrency { get; set; } = null!;

    public decimal PriceScalingFactor { get; set; }

    public string Currency { get; set; } = null!;

    public decimal QuoteFactor { get; set; }

    public virtual ICollection<MarketDatum> MarketData { get; } = new List<MarketDatum>();

    public virtual ICollection<VolumeDatum> VolumeData { get; } = new List<VolumeDatum>();
}
