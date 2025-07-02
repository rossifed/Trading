using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class TransmittedTrade
{
    public int FileTransmissionId { get; set; }

    public int TradeId { get; set; }
}
