using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class FilterCriterion
{
    public int FilterCriterionId { get; set; }

    public byte FilterPartyTypeId { get; set; }

    public byte FilterOperatorId { get; set; }

    public int FilterPartyId { get; set; }

    public virtual ICollection<Filter> FilterFilterCriterion1s { get; } = new List<Filter>();

    public virtual ICollection<Filter> FilterFilterCriterion2s { get; } = new List<Filter>();

    public virtual FilterOperator FilterOperator { get; set; } = null!;

    public virtual FilterParty FilterParty { get; set; } = null!;

    public virtual FilterPartyType FilterPartyType { get; set; } = null!;
}
