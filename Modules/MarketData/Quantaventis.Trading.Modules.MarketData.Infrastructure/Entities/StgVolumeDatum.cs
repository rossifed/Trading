using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class StgVolumeDatum
{
    public string? DL_REQUEST_ID { get; set; }

    public string? DL_REQUEST_NAME { get; set; }

    public string? DL_SNAPSHOT_START_TIME { get; set; }

    public string? DL_SNAPSHOT_TZ { get; set; }

    public string? IDENTIFIER { get; set; }

    public string? RC { get; set; }

    public string? PX_VOLUME_1D { get; set; }
}
