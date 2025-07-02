using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class vwCurrencyPair
{
    public int CurrencyPairId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public string? Exchange { get; set; }

    public string? ISIN { get; set; }

    public string? BbgGlobalId { get; set; }

    public string BbgUniqueId { get; set; } = null!;

    public string? Country { get; set; }

    public string? PrimaryMIC { get; set; }

    public string MarketSectorDes { get; set; } = null!;

    public byte BaseCurrencyId { get; set; }

    public string BaseCurrencyCode { get; set; } = null!;

    public byte QuoteCurrencyId { get; set; }

    public string QuoteCurrencyCode { get; set; } = null!;

    public decimal QuoteFactor { get; set; }
}
