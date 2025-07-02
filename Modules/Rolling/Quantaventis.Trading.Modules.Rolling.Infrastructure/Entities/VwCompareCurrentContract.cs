using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class VwCompareCurrentContract
{
    public int GenericFutureId { get; set; }

    public int TableContractId { get; set; }

    public int ViewContractId { get; set; }

    public string TableSymbol { get; set; } = null!;

    public string ViewSymbol { get; set; } = null!;

    public int ContractDiverge { get; set; }

    public decimal? TableVolume { get; set; }

    public DateTime? TableRollingPeriodStart { get; set; }

    public DateTime TableRollingPeriodEnd { get; set; }

    public decimal? ViewVolume { get; set; }

    public DateTime? ViewRollingPeriodStart { get; set; }

    public DateTime ViewRollingPeriodEnd { get; set; }
}
