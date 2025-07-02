using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Description { get; set; } = null!;
}
