using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;

public partial class EmsxOrder
{
    public int EmsxSequence { get; set; }

    public int? Amount { get; set; }

    public string? Broker { get; set; }

    public string? HandInstruction { get; set; }

    public string? OrderType { get; set; }

    public string? Ticker { get; set; }

    public string? TimeInForce { get; set; }

    public string? OrderOrigin { get; set; }

    public long? ApiSeqNum { get; set; }

    public int? OrderNumber { get; set; }

    public string? Side { get; set; }

    public string? Account { get; set; }

    public string? BasketName { get; set; }

    public string? Strategy { get; set; }

    public string? ClearingAccount { get; set; }

    public string? ClearingFirm { get; set; }

    public string? CustomNote1 { get; set; }

    public string? CustomNote2 { get; set; }

    public string? CustomNote3 { get; set; }

    public string? CustomNote4 { get; set; }

    public string? CustomNote5 { get; set; }

    public string? ExchangeDestination { get; set; }

    public string? ExecInstruction { get; set; }

    public string? Warnings { get; set; }

    public DateTime? GtdDate { get; set; }

    public string? InvestorId { get; set; }

    public decimal? LimitPrice { get; set; }

    public string? LocateBroker { get; set; }

    public string? LocateId { get; set; }

    public string? LocateRequest { get; set; }

    public string? Notes { get; set; }

    public int? OddLot { get; set; }

    public string? OrderRefId { get; set; }

    public TimeSpan? ReleaseTime { get; set; }

    public int? RequestSequence { get; set; }

    public string? SettlementCurrency { get; set; }

    public DateTime? SettlementDate { get; set; }

    public string? SettlementType { get; set; }

    public decimal? SettlementPrice { get; set; }

    public decimal? StopPrice { get; set; }

    public int? TraderUuid { get; set; }

    public decimal? ArrivalPrice { get; set; }

    public string? AssetClass { get; set; }

    public string? AssignedTrader { get; set; }

    public decimal? AvgPrice { get; set; }

    public int? BasketNum { get; set; }

    public decimal? BrokerComm { get; set; }

    public decimal? BseAvgPrice { get; set; }

    public int? BseFilled { get; set; }

    public string? CfdFlag { get; set; }

    public string? CommDiffFlag { get; set; }

    public decimal? CommRate { get; set; }

    public string? CurrencyPair { get; set; }

    public DateTime? Date { get; set; }

    public decimal? DayAvgPrice { get; set; }

    public int? DayFill { get; set; }

    public string? DirBrokerFlag { get; set; }

    public string? Exchange { get; set; }

    public int? FillId { get; set; }

    public int? Filled { get; set; }

    public int? IdleAmount { get; set; }

    public string? Isin { get; set; }

    public decimal? NseAvgPrice { get; set; }

    public int? NseFilled { get; set; }

    public string? OriginateTrader { get; set; }

    public string? OriginateTraderFirm { get; set; }

    public decimal? PercentRemain { get; set; }

    public int? PmUuid { get; set; }

    public string? PortMgr { get; set; }

    public string? PortName { get; set; }

    public int? PortNum { get; set; }

    public string? Position { get; set; }

    public decimal? Principal { get; set; }

    public string? Product { get; set; }

    public int? QueuedDate { get; set; }

    public int? QueuedTime { get; set; }

    public string? ReasonCode { get; set; }

    public string? ReasonDescription { get; set; }

    public decimal? RemainBalance { get; set; }

    public int? RouteId { get; set; }

    public decimal? RoutePrice { get; set; }

    public string? SecName { get; set; }

    public string? Sedol { get; set; }

    public decimal? SettleAmount { get; set; }

    public DateTime? SettleDate { get; set; }

    public int? StartAmount { get; set; }

    public string? Status { get; set; }

    public string? StepOutBrooker { get; set; }

    public int? StrategyEndTime { get; set; }

    public decimal? StrategyPartRate1 { get; set; }

    public decimal? StrategyPartRate2 { get; set; }

    public int? StrategyStartTime { get; set; }

    public string? StrategyStyle { get; set; }

    public string? StrategyType { get; set; }

    public TimeSpan? TimeStamp { get; set; }

    public string? TradeDesk { get; set; }

    public string? Trader { get; set; }

    public string? TraderNotes { get; set; }

    public int? TsOrdNum { get; set; }

    public string? Type { get; set; }

    public string? UnderlyingTicker { get; set; }

    public decimal? UserCommAmount { get; set; }

    public decimal? UserCommRate { get; set; }

    public decimal? UserFees { get; set; }

    public decimal? UserNetMoney { get; set; }

    public decimal? UserWorkPrice { get; set; }

    public int? Working { get; set; }

    public string? YellowKey { get; set; }

    public string? BookName { get; set; }

    public string? LocateReq { get; set; }

    public int? Pa { get; set; }

    public string? RouteRefId { get; set; }
}
