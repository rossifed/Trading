using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public virtual FutureContract? FutureContract { get; set; }

    public virtual InstrumentPricing? InstrumentPricing { get; set; }

    public virtual ICollection<Position> Positions { get; } = new List<Position>();

    public virtual ICollection<TargetWeight> TargetWeights { get; } = new List<TargetWeight>();
}
