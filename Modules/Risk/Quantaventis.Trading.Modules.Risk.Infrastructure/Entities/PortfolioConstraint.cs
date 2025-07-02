using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class PortfolioConstraint
{
    public int PortfolioConstraintId { get; set; }

    public byte PortfolioId { get; set; }

    public int ConstraintId { get; set; }

    public virtual Constraint Constraint { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;
}
