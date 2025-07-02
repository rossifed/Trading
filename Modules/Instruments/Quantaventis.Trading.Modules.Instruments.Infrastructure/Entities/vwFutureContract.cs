using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class vwFutureContract
{
    public int FutureContractId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Currency { get; set; }

    public string? Exchange { get; set; }

    public string? ISIN { get; set; }

    public string? BbgGlobalId { get; set; }

    public string BbgUniqueId { get; set; } = null!;

    public string? Country { get; set; }

    public string? PrimaryMIC { get; set; }

    public string MarketSectorDes { get; set; } = null!;

    public decimal PriceScalingFactor { get; set; }

    public string? QuoteCurrency { get; set; }

    public int GenericFutureId { get; set; }

    public string GenericFutureSymbol { get; set; } = null!;

    public string RootSymbol { get; set; } = null!;

    public decimal ContractSize { get; set; }

    public decimal TickSize { get; set; }

    public decimal TickValue { get; set; }

    public decimal PointValue { get; set; }

    public byte FutureContractMonthId { get; set; }

    public string? MonthCode { get; set; }

    public string? MonthMnemonic { get; set; }

    public string? MonthName { get; set; }

    public int ContractYear { get; set; }

    public DateTime LastTradeDate { get; set; }

    public DateTime FirstNoticeDate { get; set; }

    public DateTime FirstDeliveryDate { get; set; }

    public DateTime RollDate { get; set; }
}
