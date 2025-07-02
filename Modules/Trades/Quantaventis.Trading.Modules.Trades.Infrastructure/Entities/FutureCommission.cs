using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class FutureCommission
{
    public int FutureCommissionId { get; set; }

    public string BrokerCode { get; set; } = null!;

    public int? GenericFutureId { get; set; }

    public decimal? CommPerLot { get; set; }

    public decimal? CommRate { get; set; }

    public decimal? ExecDeskCommPerLot { get; set; }

    public decimal? ExecDeskCommRate { get; set; }
}
