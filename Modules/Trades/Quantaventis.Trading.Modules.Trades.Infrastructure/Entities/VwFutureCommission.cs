using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

public partial class VwFutureCommission
{
    public int FutureCommissionId { get; set; }

    public string BrokerCode { get; set; } = null!;

    public int? GenericFutureId { get; set; }

    public string Symbol { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public decimal? CommPerLot { get; set; }

    public decimal? CommRate { get; set; }

    public decimal? ExecDeskCommPerLot { get; set; }

    public decimal? ExecDeskCommRate { get; set; }
}
