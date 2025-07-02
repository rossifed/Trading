using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class TradeInstrumentType
{
    public int TradeInstrumentTypeId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public bool IsSwap { get; set; }

    public string Name { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public virtual ICollection<ClearingAccount> ClearingAccounts { get; } = new List<ClearingAccount>();
}
