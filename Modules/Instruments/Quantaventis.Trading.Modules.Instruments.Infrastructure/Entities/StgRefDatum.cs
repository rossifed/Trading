using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class StgRefDatum
{
    public string? DL_REQUEST_ID { get; set; }

    public string? DL_REQUEST_NAME { get; set; }

    public string? DL_SNAPSHOT_START_TIME { get; set; }

    public string? DL_SNAPSHOT_TZ { get; set; }

    public string? IDENTIFIER { get; set; }

    public string? RC { get; set; }

    public string? BASE_CRNCY { get; set; }

    public string? BB_TO_EXCH_PX_SCALING_FACTOR { get; set; }

    public string? COUNTRY { get; set; }

    public string? COUNTRY_ISO { get; set; }

    public string? CRNCY { get; set; }

    public string? EXCH_CODE { get; set; }

    public string? FUT_CONT_SIZE { get; set; }

    public string? FUT_CUR_GEN_TICKER { get; set; }

    public string? FUT_DLV_DT_FIRST { get; set; }

    public string? FUT_EXCH_NAME_LONG { get; set; }

    public string? FUT_MONTH_YR { get; set; }

    public string? FUT_NOTICE_FIRST { get; set; }

    public string? FUT_ROLL_DT { get; set; }

    public string? FUT_TICK_SIZE { get; set; }

    public string? FUT_TICK_VAL { get; set; }

    public string? FUT_VAL_PT { get; set; }

    public string? ID_BB_GLOBAL { get; set; }

    public string? ID_BB_UNIQUE { get; set; }

    public string? ID_ISIN { get; set; }

    public string? ID_MIC_LOCAL_EXCH { get; set; }

    public string? ID_MIC_PRIM_EXCH { get; set; }

    public string? MARKET_SECTOR_DES { get; set; }

    public string? NAME { get; set; }

    public string? PX_SCALING_FACTOR { get; set; }

    public string? QUOTE_FACTOR { get; set; }

    public string? QUOTED_CRNCY { get; set; }

    public string? SECURITY_TYP { get; set; }

    public string? SECURITY_TYP2 { get; set; }

    public string? TIME_ZONE_NUM { get; set; }

    public string? EXCHANGE_TRADING_SESSION_HOURS_BC_SESSION { get; set; }

    public string? EXCHANGE_TRADING_SESSION_HOURS_FUT_TRADING_HRS { get; set; }

    public string? LAST_TRADEABLE_DT { get; set; }
}
