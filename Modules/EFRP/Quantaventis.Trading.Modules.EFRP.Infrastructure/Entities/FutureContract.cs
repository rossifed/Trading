using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;

public partial class FutureContract
{
    public int FutureContractId { get; set; }

    public string Symbol { get; set; } = null!;

    public int GenericFutureId { get; set; }

    public DateTime LastTradeDate { get; set; }

    public virtual GenericFuture GenericFuture { get; set; } = null!;
}
