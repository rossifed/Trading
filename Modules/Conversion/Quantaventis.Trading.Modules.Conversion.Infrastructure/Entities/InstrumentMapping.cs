using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

public partial class InstrumentMapping
{
    public int FromInstrumentId { get; set; }

    public int ToInstrumentId { get; set; }

    public byte InstrumentMappingTypeId { get; set; }

    public virtual Instrument FromInstrument { get; set; } = null!;

    public virtual InstrumentMappingType InstrumentMappingType { get; set; } = null!;

    public virtual Instrument ToInstrument { get; set; } = null!;
}
