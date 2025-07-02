using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

public partial class TargetWeightConversion
{
    public int TargetWeightConversionId { get; set; }

    public int TargetAllocationConversionId { get; set; }

    public int FromInstrumentId { get; set; }

    public int FromSymbol { get; set; }

    public decimal FromWeight { get; set; }

    public int ToInstrumentId { get; set; }

    public int ToSymbol { get; set; }

    public decimal ToWeight { get; set; }

    public virtual Instrument FromInstrument { get; set; } = null!;

    public virtual TargetAllocationConversion TargetAllocationConversion { get; set; } = null!;

    public virtual Instrument ToInstrument { get; set; } = null!;
}
