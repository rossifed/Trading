using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Isin { get; set; }

    public string BbgUniqueId { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string MarketSector { get; set; } = null!;

    public string? Exchange { get; set; }

    public string? PrimaryMic { get; set; }

    public string Currency { get; set; } = null!;

    public string QuoteCurrency { get; set; } = null!;

    public DateTime? MaturityDate { get; set; }

    public decimal PriceScalingFactor { get; set; }

    public decimal? FuturePointValue { get; set; }

    public int? GenericFutureId { get; set; }

    public virtual ICollection<StgTradeToBook> StgTradeToBooks { get; } = new List<StgTradeToBook>();

    public virtual ICollection<Trade> Trades { get; } = new List<Trade>();
}
