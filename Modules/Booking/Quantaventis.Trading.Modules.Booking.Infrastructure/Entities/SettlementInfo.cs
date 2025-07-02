using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class SettlementInfo
{
    public int CounterpartyId { get; set; }

    public int InstrumentId { get; set; }

    public bool IsSwap { get; set; }

    public byte DaysToSettle { get; set; }

    public string SettleCurrency { get; set; } = null!;

    public virtual Counterparty Counterparty { get; set; } = null!;

    public virtual Instrument Instrument { get; set; } = null!;
}
