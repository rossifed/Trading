using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Entities;

public partial class StgMarketDatum
{
    public string? DL_REQUEST_ID { get; set; }

    public string? DL_REQUEST_NAME { get; set; }

    public string? DL_SNAPSHOT_START_TIME { get; set; }

    public string? DL_SNAPSHOT_TZ { get; set; }

    public string? IDENTIFIER { get; set; }

    public string? RC { get; set; }

    public string? CUR_MKT_CAP { get; set; }

    public string? LAST_TRADE_DATE { get; set; }

    public string? LAST_UPDATE { get; set; }

    public string? LAST_UPDATE_DATE_EOD { get; set; }

    public string? LAST_UPDATE_DT { get; set; }

    public string? PX_CLOSE_DT { get; set; }

    public string? PX_LAST { get; set; }

    public string? PX_LAST_EOD { get; set; }

    public string? PX_YEST_CLOSE { get; set; }

    public string? VOLUME_AVG_30D { get; set; }

    public string? PX_YEST_DT { get; set; }
}
