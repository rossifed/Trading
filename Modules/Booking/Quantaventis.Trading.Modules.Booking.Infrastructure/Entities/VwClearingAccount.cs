using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class VwClearingAccount
{
    public int ClearingAccountId { get; set; }

    public byte PortfolioId { get; set; }

    public string PortfolioMnemonic { get; set; } = null!;

    public string TradeInstrumentType { get; set; } = null!;

    public bool IsSwap { get; set; }

    public string ClearingBroker { get; set; } = null!;

    public string ClearingAccount { get; set; } = null!;

    public string? Description { get; set; }
}
