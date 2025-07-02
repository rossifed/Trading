using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class FutureContract
{
    public int FutureContractId { get; set; }

    public decimal PointValue { get; set; }

    public string PointValueCurrency { get; set; } = null!;

    public virtual Instrument FutureContractNavigation { get; set; } = null!;
}
