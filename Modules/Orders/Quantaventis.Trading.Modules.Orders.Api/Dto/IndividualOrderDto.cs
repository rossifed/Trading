using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.Dto
{
    public class IndividualOrderDto
    {

        public int BlockOrderId { get; set; }
        public int InstrumentId { get; set; }
        public string Symbol { get; set; }
        public DateOnly TradeDate { get; set; }



        public int BrokerId { get; set; }

        public string BrokerCode { get; set; }

        public IEnumerable<ExecutionAlgoParamDto> ExecutionAlgoParams { get; set; }
        public string ExecutionAlgorithm { get; set; }
        public string OrderType { get; set; }
        public string TimeInForce { get; set; }
        public string HandlingInstruction { get; set; }
        public string ExecutionChannel { get; set; }

        public string TradeMode { get; set; }
        public int TradingAccountId { get; set; }
        public string TradingAccount { get; set; }
        public int PortfolioId { get; set; }
        public int Quantity { get; set; }
    }
}
