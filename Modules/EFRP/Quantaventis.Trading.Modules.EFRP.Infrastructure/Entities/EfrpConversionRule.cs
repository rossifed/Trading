using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;

public partial class EfrpConversionRule
{
    public int EfrpConversionRuleId { get; set; }

    public int GenericFutureId { get; set; }

    public int BrokerId { get; set; }

    public string BaseCurrency { get; set; } = null!;

    public string QuoteCurrency { get; set; } = null!;

    public string? CmeClearportTicker { get; set; }

    public bool IsActive { get; set; }

    public virtual Broker Broker { get; set; } = null!;

    public virtual GenericFuture GenericFuture { get; set; } = null!;
}
