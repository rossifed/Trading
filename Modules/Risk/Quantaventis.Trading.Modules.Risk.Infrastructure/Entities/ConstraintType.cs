using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class ConstraintType
{
    public short ConstraintTypeId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Constraint> Constraints { get; } = new List<Constraint>();
}
