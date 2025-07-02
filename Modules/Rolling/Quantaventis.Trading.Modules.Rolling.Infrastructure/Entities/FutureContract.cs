using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class FutureContract
{
    public int FutureContractId { get; set; }

    public string Symbol { get; set; } = null!;

    public int GenericFutureId { get; set; }

    public DateTime LastTradeDate { get; set; }

    public DateTime FirstNoticeDate { get; set; }

    public DateTime FirstDeliveryDate { get; set; }

    public DateTime RollDate { get; set; }

    public decimal? Volume { get; set; }
}
