using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

public partial class TargetAllocationConversion
{
    public int TargetAllocationConversionId { get; set; }

    public int TargetAllocationId { get; set; }

    public DateTime ConvertedOn { get; set; }

    public virtual ICollection<TargetWeightConversion> TargetWeightConversions { get; } = new List<TargetWeightConversion>();
}
