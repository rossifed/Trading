using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class GenericFuture
{
    public int GenericFutureId { get; set; }

    public string RootSymbol { get; set; } = null!;

    public decimal ContractSize { get; set; }

    public decimal TickSize { get; set; }

    public decimal TickValue { get; set; }

    public decimal PointValue { get; set; }

    public virtual ICollection<FutureContract> FutureContracts { get; } = new List<FutureContract>();

    public virtual Instrument GenericFutureNavigation { get; set; } = null!;
}
