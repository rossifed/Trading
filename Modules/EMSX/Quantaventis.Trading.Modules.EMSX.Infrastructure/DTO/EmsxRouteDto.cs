namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO
{
    public class EmsxRouteDto
    {
        public long ApiSeqNum { get; set; }
        public String Account { get; set; }
        public int Amount { get; set; }
        public Double AvgPrice { get; set; }
        public String Broker { get; set; }
        public Double BrokerComm { get; set; }
        public Double BseAvgPrice { get; set; }
        public int BseFilled { get; set; }
        public String ClearingAccount { get; set; }
        public String ClearingFirm { get; set; }
        public String CommDiffFlag { get; set; }
        public Double CommRate { get; set; }
        public String CurrencyPair { get; set; }
        public String CustomAccount { get; set; }
        public Double DayAvgPrice { get; set; }
        public int DayFill { get; set; }
        public String ExchangeDestination { get; set; }
        public String ExecInstruction { get; set; }
        public String ExecuteBroker { get; set; }
        public int FillId { get; set; }
        public int Filled { get; set; }
        public int GtdDate { get; set; }
        public String HandInstruction { get; set; }
        public int IsManualRoute { get; set; }
        public int LastFillDate { get; set; }
        public int LastFillTime { get; set; }
        public String LastMarket { get; set; }
        public Double LastPrice { get; set; }
        public int LastShares { get; set; }
        public Double LimitPrice { get; set; }
        public Double Misc_fees { get; set; }
        public int MlLegQuantity { get; set; }
        public int MlNumLegs { get; set; }
        public Double MlPercentFilled { get; set; }
        public Double MlRation { get; set; }
        public Double MlRemainBalance { get; set; }
        public String MlStrategy { get; set; }
        public int MlTotalQuantity { get; set; }
        public String Notes { get; set; }
        public Double NseAvgPrice { get; set; }
        public int NseFilled { get; set; }
        public String OrderType { get; set; }
        public String Pa { get; set; }
        public Double PercentRemain { get; set; }
        public Double Principal { get; set; }
        public int QueuedDate { get; set; }
        public int QueuedTime { get; set; }
        public String ReasonCode { get; set; }
        public String ReasonDescription { get; set; }
        public Double RemainBalance { get; set; }
        public int RouteCreateDate { get; set; }
        public int RouteCreateTime { get; set; }
        public int RouteId { get; set; }
        public String RouteRefId { get; set; }
        public int RouteLastUpdateTime { get; set; }
        public Double RoutePrice { get; set; }
        public int Sequence { get; set; }
        public Double SettleAmount { get; set; }
        public int SettleDate { get; set; }
        public String Status { get; set; }
        public Double StopPrice { get; set; }
        public int StrategyEndTime { get; set; }
        public Double StrategyPartRate1 { get; set; }
        public Double StrategyPartRate2 { get; set; }
        public int StrategyStartTime { get; set; }
        public String StrategyStyle { get; set; }
        public String StrategyType { get; set; }
        public String Tif { get; set; }
        public int TimeStamp { get; set; }
        public String Type { get; set; }
        public int UrgencyLevel { get; set; }
        public Double UserCommAmount { get; set; }
        public Double UserCommRate { get; set; }
        public Double UserFees { get; set; }
        public Double UserNetMoney { get; set; }
        public int Working { get; set; }

        public override string? ToString()
        {
            return $"{Sequence} {RouteId} {Amount} {AvgPrice} {Status}";
        }
    }
}
