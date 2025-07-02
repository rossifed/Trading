using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Api.Dto
{
    public class EfrpTradeDto
    {
        public IEnumerable<EfrpDealDto> EfrpDeals { get; set;}

        public string Exchange { get; set;}
        public string BloombergSymbol { get; set;}
        public string ExchangeSymbol { get; set;}

        public string ClientSide{ get; set; }
        public int Quantity { get; set;}

        public string Ccy1 { get; set;}

        public decimal Ccy1Amount { get; set;}

        public decimal FutureRate { get; set;}

        public DateOnly TradeDate { get; set;}
  
    

        public DateTime LastUpdateTimeUtc { get; set;}
        public DateTime FirstDealEntryTimeUtc { get; set;}

        public DateTime LastDealEntryTimeUtc { get; set;}
   
        public decimal AvgPrice { get; set;}
      
        public int FutureContractId { get; set;}

        public decimal PointValue { get; set; }


        public byte? NumberOfDeals { get; set; }


        public decimal? MaxDealPrice { get; set; }


        public decimal? MinDealPrice { get; set; }
        public decimal Principal { get; set; }

        public decimal TradeValue { get; set; }
    }
}
