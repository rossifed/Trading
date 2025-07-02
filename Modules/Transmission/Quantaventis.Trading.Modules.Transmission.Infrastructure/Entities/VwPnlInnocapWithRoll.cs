using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class VwPnlInnocapWithRoll
{
    public string? AssetType { get; set; }

    public string? Ticker { get; set; }

    public string BloombergId { get; set; } = null!;

    public string Cusip { get; set; } = null!;

    public string Isin { get; set; } = null!;

    public string Sedol { get; set; } = null!;

    public string SideLongShort { get; set; } = null!;

    public int SharesNotional { get; set; }

    public string? Ccy { get; set; }

    public decimal LocalCost { get; set; }

    public decimal? BaseCost { get; set; }

    public decimal? LocalPrice { get; set; }

    public decimal? BasePrice { get; set; }

    public decimal? LocalMv { get; set; }

    public decimal? BaseMv { get; set; }

    public string ClearingBroker { get; set; } = null!;

    public decimal? TotalDailyPnlRealizedUnrealizedLocal { get; set; }

    public decimal? TotalDailyPnlRealizedUnrealizedBase { get; set; }

    public string TotalMtdPnlRealizedUnrealizedLocal { get; set; } = null!;

    public string TotalMtdPnlRealizedUnrealizedBase { get; set; } = null!;

    public decimal? FxRate { get; set; }

    public string Daily { get; set; } = null!;

    public string Mtd { get; set; } = null!;
}
