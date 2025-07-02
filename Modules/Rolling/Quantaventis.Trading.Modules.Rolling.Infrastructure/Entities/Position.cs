using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class Position
{
    public byte PortfolioId { get; set; }

    public int GenericId { get; set; }

    public int ContractId { get; set; }

    public int Quantity { get; set; }

    public DateTime PositionDate { get; set; }

    public string Currency { get; set; } = null!;

    public bool IsSwap { get; set; }
}
