using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class IndustryGroup
{
    public int IndustryGroupId { get; set; }

    public int Number { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Instrument> Instruments { get; } = new List<Instrument>();
}
