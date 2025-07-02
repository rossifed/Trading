using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;

public partial class Broker
{
    public int BrokerId { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<EfrpConversionRule> EfrpConversionRules { get; } = new List<EfrpConversionRule>();
}
