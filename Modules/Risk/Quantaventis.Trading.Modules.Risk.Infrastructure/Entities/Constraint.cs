using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class Constraint
{
    public int ConstraintId { get; set; }

    public short ConstraintTypeId { get; set; }

    public byte RelationalOperatorId { get; set; }

    public decimal LimitValue { get; set; }

    public string? Description { get; set; }

    public int? FilterId { get; set; }

    public virtual ICollection<ConstraintBreach> ConstraintBreaches { get; } = new List<ConstraintBreach>();

    public virtual ConstraintType ConstraintType { get; set; } = null!;

    public virtual Filter? Filter { get; set; }

    public virtual ICollection<PortfolioConstraint> PortfolioConstraints { get; } = new List<PortfolioConstraint>();

    public virtual RelationalOperator RelationalOperator { get; set; } = null!;
}
