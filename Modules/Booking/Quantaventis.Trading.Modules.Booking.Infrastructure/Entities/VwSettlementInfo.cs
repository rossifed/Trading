using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class VwSettlementInfo
{
    public string Counterparty { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string? Exchange { get; set; }

    public bool IsSwap { get; set; }

    public byte DaysToSettle { get; set; }

    public string SettleCurrency { get; set; } = null!;
}
