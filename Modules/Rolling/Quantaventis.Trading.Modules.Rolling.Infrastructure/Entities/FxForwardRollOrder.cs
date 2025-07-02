using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class FxForwardRollOrder
{
    public byte FutureRollOrderId { get; set; }

    public byte PortfolioId { get; set; }

    public int RolledQuantity { get; set; }

    public int CurrencyPairId { get; set; }

    public string CurrencyPairSymbol { get; set; } = null!;

    public int ExpiringContractId { get; set; }

    public string ExpiringContractSymbol { get; set; } = null!;

    public DateTime ExpiringContractMaturity { get; set; }

    public int NextContractId { get; set; }

    public string NextContractSymbol { get; set; } = null!;

    public DateTime NextContractMaturity { get; set; }

    public DateTime RollDate { get; set; }
}
