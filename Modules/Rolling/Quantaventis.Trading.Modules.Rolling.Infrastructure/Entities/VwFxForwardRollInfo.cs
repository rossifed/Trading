using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class VwFxForwardRollInfo
{
    public int CurrencyPairId { get; set; }

    public int CurrentContractId { get; set; }

    public string CurrentSymbol { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public DateTime? RollingPeriodStartDate { get; set; }

    public int? DayToRollingPeriodStart { get; set; }

    public int? DayToExpiry { get; set; }

    public int IsRollingPeriod { get; set; }

    public int? NextContractId { get; set; }

    public DateTime? NextMaturityDate { get; set; }

    public string? NextSymbol { get; set; }
}
