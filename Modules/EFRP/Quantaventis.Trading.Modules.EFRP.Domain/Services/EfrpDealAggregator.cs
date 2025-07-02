using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Services
{
    internal interface IEfrpDealAggregator {
        IEnumerable<EfrpTrade> Aggregate(IEnumerable<EfrpDeal> efrpDeals);
    }
    internal class EfrpDealAggregator: IEfrpDealAggregator
    {

      public  IEnumerable<EfrpTrade> Aggregate(IEnumerable<EfrpDeal> efrpDeals) {
           

          return  efrpDeals
                .ToLookup(x => (x.Exchange, x.BloombergSymbol, x.ExchangeSymbol, x.DealSide, x.Currency, x.TradeDate))
                .Select(x=>new EfrpTrade(x));
        
        }
    }
}
