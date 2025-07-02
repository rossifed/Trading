using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class Country
{
    public short CountryId { get; set; }

    public string Name { get; set; } = null!;

    public string IsoAlpha2Code { get; set; } = null!;

    public virtual ICollection<Instrument> Instruments { get; } = new List<Instrument>();
}
