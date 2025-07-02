using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class FutureContract
{
    public int FutureContractId { get; set; }

    public int GenericFutureId { get; set; }

    public byte FutureContractMonthId { get; set; }

    public int ContractYear { get; set; }

    public DateTime LastTradeDate { get; set; }

    public DateTime FirstNoticeDate { get; set; }

    public DateTime FirstDeliveryDate { get; set; }

    public DateTime RollDate { get; set; }

    public virtual FutureContractMonth FutureContractMonth { get; set; } = null!;

    public virtual Instrument FutureContractNavigation { get; set; } = null!;

    public virtual GenericFuture GenericFuture { get; set; } = null!;
}
