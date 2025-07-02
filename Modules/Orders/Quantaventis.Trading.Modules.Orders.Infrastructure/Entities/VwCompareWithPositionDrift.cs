using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class VwCompareWithPositionDrift
{
    public string Symbol { get; set; } = null!;

    public int QuantityDrift { get; set; }

    public int AllocationQuantity { get; set; }

    public int IsMismatch { get; set; }
}
