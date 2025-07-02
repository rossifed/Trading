using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;

public partial class EmsxRoute
{
    public int RouteId { get; set; }

    public long? ApiSeqNum { get; set; }

    public string? Account { get; set; }

    public int? Amount { get; set; }

    public decimal? AvgPrice { get; set; }

    public string? Broker { get; set; }

    public decimal? BrokerComm { get; set; }

    public decimal? BseAvgPrice { get; set; }

    public int? BseFilled { get; set; }

    public string? ClearingAccount { get; set; }

    public string? ClearingFirm { get; set; }

    public string? CommDiffFlag { get; set; }

    public decimal? CommRate { get; set; }

    public string? CurrencyPair { get; set; }

    public string? CustomAccount { get; set; }

    public decimal? DayAvgPrice { get; set; }

    public int? DayFill { get; set; }

    public string? ExchangeDestination { get; set; }

    public string? ExecInstruction { get; set; }

    public string? ExecuteBroker { get; set; }

    public int? FillId { get; set; }

    public int? Filled { get; set; }

    public int? GtdDate { get; set; }

    public string? HandInstruction { get; set; }

    public int? IsManualRoute { get; set; }

    public int? LastFillDate { get; set; }

    public int? LastFillTime { get; set; }

    public string? LastMarket { get; set; }

    public decimal? LastPrice { get; set; }

    public int? LastShares { get; set; }

    public decimal? LimitPrice { get; set; }

    public decimal? MiscFees { get; set; }

    public int? MlLegQuantity { get; set; }

    public int? MlNumLegs { get; set; }

    public decimal? MlPercentFilled { get; set; }

    public decimal? MlRation { get; set; }

    public decimal? MlRemainBalance { get; set; }

    public string? MlStrategy { get; set; }

    public int? MlTotalQuantity { get; set; }

    public string? Notes { get; set; }

    public decimal? NseAvgPrice { get; set; }

    public int? NseFilled { get; set; }

    public string? OrderType { get; set; }

    public string? Pa { get; set; }

    public decimal? PercentRemain { get; set; }

    public decimal? Principal { get; set; }

    public int? QueuedDate { get; set; }

    public int? QueuedTime { get; set; }

    public string? ReasonCode { get; set; }

    public string? ReasonDescription { get; set; }

    public decimal? RemainBalance { get; set; }

    public int? RouteCreateDate { get; set; }

    public int? RouteCreateTime { get; set; }

    public string? RouteRefId { get; set; }

    public int? RouteLastUpdateTime { get; set; }

    public decimal? RoutePrice { get; set; }

    public int Sequence { get; set; }

    public decimal? SettleAmount { get; set; }

    public int? SettleDate { get; set; }

    public string? Status { get; set; }

    public decimal? StopPrice { get; set; }

    public int? StrategyEndTime { get; set; }

    public decimal? StrategyPartRate1 { get; set; }

    public decimal? StrategyPartRate2 { get; set; }

    public int? StrategyStartTime { get; set; }

    public string? StrategyStyle { get; set; }

    public string? StrategyType { get; set; }

    public string? Tif { get; set; }

    public int? TimeStamp { get; set; }

    public string? Type { get; set; }

    public int? UrgencyLevel { get; set; }

    public decimal? UserCommAmount { get; set; }

    public decimal? UserCommRate { get; set; }

    public decimal? UserFees { get; set; }

    public decimal? UserNetMoney { get; set; }

    public int? Working { get; set; }
}
