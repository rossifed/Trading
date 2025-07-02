using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class Cfd
{
    public int CfdId { get; set; }

    public int UnderlyingInstrumentId { get; set; }
}
