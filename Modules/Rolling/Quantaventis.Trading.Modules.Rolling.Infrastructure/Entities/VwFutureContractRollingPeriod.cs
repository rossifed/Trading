using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class VwFutureContractRollingPeriod
{
    public int FutureContractId { get; set; }

    public string Symbol { get; set; } = null!;

    public int GenericFutureId { get; set; }

    public DateTime? RollingPeriodStart { get; set; }

    public DateTime RollingPeriodEnd { get; set; }
}
