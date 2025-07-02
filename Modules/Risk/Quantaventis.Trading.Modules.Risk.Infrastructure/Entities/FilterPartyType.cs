using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class FilterPartyType
{
    public byte FilterPartyTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Mnemonic { get; set; } = null!;

    public virtual ICollection<FilterCriterion> FilterCriteria { get; } = new List<FilterCriterion>();
}
