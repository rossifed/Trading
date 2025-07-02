using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class PositionSide
{
    public byte PositionSideId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<OrderAllocation> OrderAllocations { get; } = new List<OrderAllocation>();
}
