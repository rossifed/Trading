using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class VwFutureContractRollInfo
{
    public int GenericFutureId { get; set; }

    public int CurrentContractId { get; set; }

    public decimal? Volume { get; set; }

    public DateTime MaturityDate { get; set; }

    public string Symbol { get; set; } = null!;

    public DateTime? RollingPeriodStartDate { get; set; }

    public int? DayToLastRollingDate { get; set; }

    public int? DayToFirstRollingDate { get; set; }

    public long? RankNum { get; set; }

    public int IsBusinessDayRoll { get; set; }

    public int IsLiquidityLow { get; set; }
}
