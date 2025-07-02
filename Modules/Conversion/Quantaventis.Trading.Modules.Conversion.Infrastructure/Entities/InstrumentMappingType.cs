using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

public partial class InstrumentMappingType
{
    public byte InstrumentMappingTypeId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public virtual ICollection<InstrumentMapping> InstrumentMappings { get; } = new List<InstrumentMapping>();
}
