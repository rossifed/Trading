using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;

public partial class VwFutureContractVolumeRank
{
    public int GenericFutureId { get; set; }

    public int FutureContractId { get; set; }

    public string Symbol { get; set; } = null!;

    public decimal? Volume { get; set; }

    public long? VolumeRank { get; set; }
}
