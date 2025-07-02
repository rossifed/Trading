using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class VwFutureOnSwap
{
    public int ExecutionBrokerId { get; set; }

    public string ExecutionBrokerCode { get; set; } = null!;

    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string SettleCurrency { get; set; } = null!;

    public byte DaysToSettle { get; set; }
}
