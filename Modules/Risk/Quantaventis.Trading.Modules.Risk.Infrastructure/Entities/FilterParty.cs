using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class FilterParty
{
    public int FilterPartyId { get; set; }

    public byte FilterPartyTypeId { get; set; }

    public virtual ICollection<FilterCriterion> FilterCriteria { get; } = new List<FilterCriterion>();
}
