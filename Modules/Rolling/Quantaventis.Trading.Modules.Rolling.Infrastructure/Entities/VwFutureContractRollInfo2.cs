using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class VwFutureContractRollInfo2
{
    public int GenericFutureId { get; set; }

    public int FutureContractId { get; set; }

    public decimal? Volume { get; set; }

    public string Symbol { get; set; } = null!;

    public long? VolumeRank { get; set; }

    public DateTime? RollingPeriodStart { get; set; }

    public DateTime RollingPeriodEnd { get; set; }

    public int? DayToFirstRollingDate { get; set; }

    public int? DayToLastRollingDate { get; set; }

    public int IsRollingPeriod { get; set; }
}
