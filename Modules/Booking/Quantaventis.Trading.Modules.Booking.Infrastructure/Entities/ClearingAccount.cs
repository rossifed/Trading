using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class ClearingAccount
{
    public int ClearingAccountId { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public byte PortfolioId { get; set; }

    public int TradeInstrumentTypeId { get; set; }

    public int ClearingBrokerId { get; set; }

    public virtual Counterparty ClearingBroker { get; set; } = null!;

    public virtual TradeInstrumentType TradeInstrumentType { get; set; } = null!;
}
