using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class SecurityType
{
    public byte SecurityTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Instrument> Instruments { get; } = new List<Instrument>();
}
