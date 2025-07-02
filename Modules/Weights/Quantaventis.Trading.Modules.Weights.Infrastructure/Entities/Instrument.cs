using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public virtual ICollection<TargetWeight> TargetWeights { get; } = new List<TargetWeight>();
}
