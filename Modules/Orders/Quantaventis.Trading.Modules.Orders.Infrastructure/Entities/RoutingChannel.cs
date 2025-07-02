using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class RoutingChannel
{
    public byte RoutingChannelId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Description { get; set; } = null!;
}
