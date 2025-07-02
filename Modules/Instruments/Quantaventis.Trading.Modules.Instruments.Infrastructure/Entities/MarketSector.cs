using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class MarketSector
{
    public byte MarketSectorId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Instrument> Instruments { get; } = new List<Instrument>();
}
