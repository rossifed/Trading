using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class VwLastInstrumentValuation
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime PriceDate { get; set; }

    public decimal PreviousPrice { get; set; }

    public DateTime PreviousPriceDate { get; set; }

    public decimal ValuationFactor { get; set; }

    public decimal InstrumentValue { get; set; }

    public decimal PreviousInstrumentValue { get; set; }

    public decimal PriceReturn { get; set; }

    public string Currency { get; set; } = null!;
}
