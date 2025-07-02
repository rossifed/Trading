using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class RelationalOperator
{
    public byte RelationalOperatorId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Constraint> Constraints { get; } = new List<Constraint>();
}
