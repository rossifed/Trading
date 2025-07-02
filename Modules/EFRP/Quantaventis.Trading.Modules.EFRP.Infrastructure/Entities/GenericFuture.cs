using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;

public partial class GenericFuture
{
    public int GenericFutureId { get; set; }

    public string Symbol { get; set; } = null!;

    public string RootSymbol { get; set; } = null!;

    public decimal ContractSize { get; set; }

    public decimal PointValue { get; set; }

    public virtual ICollection<EfrpConversionRule> EfrpConversionRules { get; } = new List<EfrpConversionRule>();

    public virtual ICollection<FutureContract> FutureContracts { get; } = new List<FutureContract>();
}
