using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Positions.Infrastructure.Entities;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string MarketSector { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public virtual ICollection<Position> Positions { get; } = new List<Position>();
}
