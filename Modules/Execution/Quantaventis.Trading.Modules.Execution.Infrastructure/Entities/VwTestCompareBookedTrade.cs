using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;

public partial class VwTestCompareBookedTrade
{
    public string? Symbol { get; set; }

    public string? OrderReferenceId { get; set; }

    public int? FilledQuantity { get; set; }

    public int BookedQuantity { get; set; }

    public int? QuantityDiff { get; set; }

    public decimal? TradeAvgPrice { get; set; }

    public decimal BookedAvgPrice { get; set; }

    public decimal? AvgPriceDiff { get; set; }

    public decimal? Principal { get; set; }

    public decimal BookedPrincipal { get; set; }

    public decimal? PrincipalDiff { get; set; }

    public string? TradeInstrumentType { get; set; }

    public string BookedInstrumentType { get; set; } = null!;

    public string? TradeSedol { get; set; }

    public string? BookedSedol { get; set; }

    public DateTime? TradeDate { get; set; }

    public DateTime BookedTradeDate { get; set; }

    public string? TradeCurrency { get; set; }

    public string BookedTradeCurrency { get; set; } = null!;

    public bool? TradeIsCfd { get; set; }

    public bool BookedIsCfd { get; set; }
}
