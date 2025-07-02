using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class Portfolio
{
    public byte PortfolioId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal TotalValue { get; set; }

    public string Currency { get; set; } = null!;

    public virtual ICollection<Position> Positions { get; } = new List<Position>();

    public virtual ICollection<TargetAllocation> TargetAllocations { get; } = new List<TargetAllocation>();
}
