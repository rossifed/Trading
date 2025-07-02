using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class vwInstrument
{
    public int InstrumentId { get; set; }

    public byte InstrumentTypeId { get; set; }

    public string InstrumentType { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public byte CurrencyId { get; set; }

    public string Currency { get; set; } = null!;

    public short? ExchangeId { get; set; }

    public string? Exchange { get; set; }

    public string? ISIN { get; set; }

    public string? BbgGlobalId { get; set; }

    public string BbgUniqueId { get; set; } = null!;

    public short? CountryId { get; set; }

    public string? Country { get; set; }

    public short? PrimaryMICId { get; set; }

    public string? PrimaryMIC { get; set; }

    public byte MarketSectorId { get; set; }

    public string MarketSectorDes { get; set; } = null!;

    public int? IndustrySectorId { get; set; }

    public string? IndustrySector { get; set; }

    public string? IndustryGroup { get; set; }

    public int? IndustryGroupId { get; set; }

    public byte? SecurityTypeId { get; set; }

    public byte? SecurityType2Id { get; set; }

    public decimal PriceScalingFactor { get; set; }

    public byte QuoteCurrencyId { get; set; }

    public string QuoteCurrency { get; set; } = null!;

    public decimal QuoteFactor { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }
}
