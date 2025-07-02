using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class TransmissionChannel
{
    public int TransmissionChannelId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Description { get; set; } = null!;
}
