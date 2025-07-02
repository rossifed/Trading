using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class Date
{
    public int DateId { get; set; }

    public DateTime Value { get; set; }

    public bool IsIMM { get; set; }

    public bool IsForwardMaturity { get; set; }

    public bool IsWeekend { get; set; }
}
