using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class TimeZone
{
    public short TimeZoneId { get; set; }

    public string Name { get; set; } = null!;
}
