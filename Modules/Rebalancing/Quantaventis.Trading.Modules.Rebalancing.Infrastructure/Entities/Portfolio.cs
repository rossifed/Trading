using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;

public partial class Portfolio
{
    public byte PortfolioId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Currency { get; set; } = null!;
}
