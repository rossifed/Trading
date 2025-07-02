using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

public partial class BooleanOperator
{
    public byte BooleanOperatorId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public virtual ICollection<Filter> Filters { get; } = new List<Filter>();
}
