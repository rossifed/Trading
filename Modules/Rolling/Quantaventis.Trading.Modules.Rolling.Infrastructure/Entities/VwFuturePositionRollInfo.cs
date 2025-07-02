using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class VwFuturePositionRollInfo
{
    public byte PortfolioId { get; set; }

    public int PositionCurrentContractId { get; set; }

    public string PositionCurrentSymbol { get; set; } = null!;

    public decimal? CurrentContractVolume { get; set; }

    public DateTime LastTradeDate { get; set; }

    public DateTime FirstNoticeDate { get; set; }

    public int ToContractId { get; set; }

    public string ToSymbol { get; set; } = null!;

    public decimal? ToVolume { get; set; }

    public int Quantity { get; set; }

    public DateTime PositionDate { get; set; }

    public string Currency { get; set; } = null!;

    public int IsRolling { get; set; }
}
