using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class Filter
{
    public int FilterId { get; set; }

    public int FilterCriterion1Id { get; set; }

    public byte? BooleanOperatorId { get; set; }

    public int? FilterCriterion2Id { get; set; }

    public virtual BooleanOperator? BooleanOperator { get; set; }

    public virtual ICollection<Constraint> Constraints { get; } = new List<Constraint>();

    public virtual FilterCriterion FilterCriterion1 { get; set; } = null!;

    public virtual FilterCriterion? FilterCriterion2 { get; set; }
}
