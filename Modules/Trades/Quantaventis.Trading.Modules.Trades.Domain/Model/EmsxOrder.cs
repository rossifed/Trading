using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Trades.Domain.Model
{
    internal class EmsxOrder
    {
        public string Ticker { get; set; }
        public int OrderNumber { get; set; }
        public int Amount { get; set; }
        public string OrderType { get; set; }
        public string TimeInForce { get; set; }
        public string Strategy { get; set; }
        public string HandInstruction { get; set; }
        public string Side { get; set; }
        public string Account { get; set; }
        public string Broker { get; set; }
        public bool IsCfd { get; set; }
        public string? ClearingAccount { get; set; }
        public string? ClearingFirm { get; set; }

        public decimal LimitPrice { get; set; }
        public string Notes { get; set; }
        public int OddLot { get; set; }

        public string OrderRefId { get; set; }

        public string? SettlementCurrency { get; set; }
        public DateTime SettlementDate { get; set; }

        public string? SettlementType { get; set; }
        public double? SettlementPrice { get; set; }
        public double AvgPrice { get; set; }
        public double BrokerComm { get; set; }
        public int Date { get; set; }
        public double DayAvgPrice { get; set; }
        public string Exchange { get; set; }
        public int FillId { get; set; }
        public bool Filled { get; set; }
        public string? Isin { get; set; }

        public string? OriginateTrader { get; set; }
        public string? OriginateTraderFirm { get; set; }
        public string Position { get; set; }
        public double Principal { get; set; }
        public string Sedol { get; set; }
        public int Sequence { get; set; }
        public double SettleAmount { get; set; }
        public int SettleDate { get; set; }
        public string Status { get; set; }
        public string TradeDesk { get; set; }
        public string Trader { get; set; }
        IEnumerable<EmsxRoute> EmsxRoutes { get; }
    }
}
