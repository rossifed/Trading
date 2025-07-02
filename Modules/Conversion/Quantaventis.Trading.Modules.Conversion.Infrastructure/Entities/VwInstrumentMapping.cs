using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

public partial class VwInstrumentMapping
{
    public int FromInstrumentId { get; set; }

    public string FromSymbol { get; set; } = null!;

    public int ToInstrumentId { get; set; }

    public string ToSymbol { get; set; } = null!;

    public byte InstrumentMappingTypeId { get; set; }

    public string Mnemonic { get; set; } = null!;
}
