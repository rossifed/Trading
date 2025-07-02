namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO
{
    public class EmsxOrderDto
    {

        public int Sequence { get; set; }
        public int Amount { get; set; }
        public string Broker { get; set; }
        public string HandInstruction { get; set; }
        public string OrderType { get; set; }
        public string Ticker { get; set; }
        public string TimeInForce { get; set; }
        public string OrderOrigin { get; set; }


        public long? ApiSeqNum { get; set; }

        public int? OrderNumber { get; set; }




        public string Side { get; set; }

        public string Account { get; set; }

        public string? BasketName { get; set; }


        public string Strategy { get; set; }
        public string[] StrategyParameters { get; set; }


        public string? ClearingAccount { get; set; }

        public string? ClearingFirm { get; set; }

        public string CustomNote1 { get; set; }
        public string CustomNote2 { get; set; }
        public string CustomNote3 { get; set; }

        public string CustomNote4 { get; set; }

        public string CustomNote5 { get; set; }
        public string? ExchangeDestination { get; set; }

        public string? ExecInstruction { get; set; }

        public string? Warnings { get; set; }

        public DateTime? GtdDate { get; set; }

        public string? InvestorId { get; set; }

        public double? LimitPrice { get; set; }

        public string? LocateBroker { get; set; }
        public string? LocateId { get; set; }
        public string? LocateRequest { get; set; }

        public string? Notes { get; set; }
        public int? OddLot { get; set; }

        public string OrderRefId { get; set; }

        public TimeSpan? ReleaseTime { get; set; }

        public int? RequestSequence { get; set; }

        public string? SettlementCurrency { get; set; }
        public DateTime? SettlementDate { get; set; }

        public string? SettlementType { get; set; }
        public double? SettlementPrice { get; set; }

        public double? StopPrice { get; set; }

        public int? TraderUuid { get; set; }


        public double? ArrivalPrice { get; set; }
        public string? AssetClass { get; set; }
        public string? AssignedTrader { get; set; }
        public double? AvgPrice { get; set; }

        public int? BasketNum { get; set; }

        public double? BrokerComm { get; set; }
        public double? BseAvgPrice { get; set; }
        public int? BseFilled { get; set; }
        public string CfdFlag { get; set; }
        public string? CommDiffFlag { get; set; }
        public double? CommRate { get; set; }
        public string? CurrencyPair { get; set; }
        public DateTime? Date { get; set; }
        public double? DayAvgPrice { get; set; }
        public int? DayFill { get; set; }
        public string? DirBrokerFlag { get; set; }
        public string? Exchange { get; set; }

        public int? FillId { get; set; }
        public int? Filled { get; set; }

        public int? IdleAmount { get; set; }

        public string? Isin { get; set; }

        public double? NseAvgPrice { get; set; }
        public int? NseFilled { get; set; }

        public string? OriginateTrader { get; set; }
        public string? OriginateTraderFirm { get; set; }
        public double? PercentRemain { get; set; }
        public int? PmUuid { get; set; }
        public string? PortMgr { get; set; }
        public string? PortName { get; set; }
        public int? PortNum { get; set; }
        public string? Position { get; set; }
        public double? Principal { get; set; }
        public string? Product { get; set; }
        public int? QueuedDate { get; set; }
        public int? QueuedTime { get; set; }
        public string? ReasonCode { get; set; }
        public string? ReasonDescription { get; set; }
        public double? RemainBalance { get; set; }
        public int? RouteId { get; set; }
        public double? RoutePrice { get; set; }
        public string? SecName { get; set; }
        public string? Sedol { get; set; }

        public double? SettleAmount { get; set; }
        public DateTime? SettleDate { get; set; }

        public int? StartAmount { get; set; }
        public string Status { get; set; }
        public string? StepOutBrooker { get; set; }

        public int? StrategyEndTime { get; set; }
        public double? StrategyPartRate1 { get; set; }
        public double? StrategyPartRate2 { get; set; }
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
        public double? UserCommAmount { get; set; }
        public double? UserCommRate { get; set; }
        public double? UserFees { get; set; }
        public double? UserNetMoney { get; set; }
        public double? UserWorkPrice { get; set; }
        public int? Working { get; set; }
        public string? YellowKey { get; set; }

        public string? BookName { get; set; }

        public string? LocateReq { get; set; }

        public int? Pa { get; set; }

        public string? RouteRefId { get; set; }

        public override string? ToString()
        {
            return $"{Sequence} {Side} {Amount} {Ticker} {OrderType} {Status}";
        }
    }
}
