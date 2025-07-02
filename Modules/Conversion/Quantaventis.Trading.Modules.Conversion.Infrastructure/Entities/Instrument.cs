using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public virtual ICollection<InstrumentMapping> InstrumentMappingFromInstruments { get; } = new List<InstrumentMapping>();

    public virtual ICollection<InstrumentMapping> InstrumentMappingToInstruments { get; } = new List<InstrumentMapping>();

    public virtual ICollection<TargetWeightConversion> TargetWeightConversionFromInstruments { get; } = new List<TargetWeightConversion>();

    public virtual ICollection<TargetWeightConversion> TargetWeightConversionToInstruments { get; } = new List<TargetWeightConversion>();
}
