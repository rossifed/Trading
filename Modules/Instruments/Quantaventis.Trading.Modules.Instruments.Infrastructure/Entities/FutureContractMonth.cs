using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class FutureContractMonth
{
    public byte FutureContractMonthId { get; set; }

    public string Code { get; set; } = null!;

    public string Mnemonic { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<FutureContract> FutureContracts { get; } = new List<FutureContract>();
}
