using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class MIC
{
    public short MICId { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<Instrument> Instruments { get; } = new List<Instrument>();
}
