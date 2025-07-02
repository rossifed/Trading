using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public byte InstrumentTypeId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public byte CurrencyId { get; set; }

    public short? ExchangeId { get; set; }

    public string? ISIN { get; set; }

    public string? BbgGlobalId { get; set; }

    public string BbgUniqueId { get; set; } = null!;

    public short? CountryId { get; set; }

    public short? PrimaryMICId { get; set; }

    public byte MarketSectorId { get; set; }

    public int? IndustrySectorId { get; set; }

    public int? IndustryGroupId { get; set; }

    public byte? SecurityTypeId { get; set; }

    public byte? SecurityType2Id { get; set; }

    public decimal PriceScalingFactor { get; set; }

    public byte QuoteCurrencyId { get; set; }

    public decimal QuoteFactor { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual CurrencyPair? CurrencyPair { get; set; }

    public virtual Exchange? Exchange { get; set; }

    public virtual FutureContract? FutureContract { get; set; }

    public virtual FxForward? FxForward { get; set; }

    public virtual GenericFuture? GenericFuture { get; set; }

    public virtual IndustryGroup? IndustryGroup { get; set; }

    public virtual IndustrySector? IndustrySector { get; set; }

    public virtual InstrumentType InstrumentType { get; set; } = null!;

    public virtual MarketSector MarketSector { get; set; } = null!;

    public virtual MIC? PrimaryMIC { get; set; }

    public virtual Currency QuoteCurrency { get; set; } = null!;

    public virtual SecurityType? SecurityType { get; set; }

    public virtual SecurityType2? SecurityType2 { get; set; }
}
