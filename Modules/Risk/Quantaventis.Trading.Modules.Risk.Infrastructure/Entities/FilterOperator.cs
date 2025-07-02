using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class FilterOperator
{
    public byte FilterOperatorId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<FilterCriterion> FilterCriteria { get; } = new List<FilterCriterion>();
}
