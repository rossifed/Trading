using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class EfrpTrade
    {
        internal IEnumerable<EfrpDeal> EfrpDeals { get; }

        internal string Exchange { get; }
        internal string BloombergSymbol { get; }
        internal string ExchangeSymbol { get; }

        internal string ClientSide{get;}
        internal int Quantity { get; }

        internal string Ccy1 { get; }

        internal decimal Ccy1Amount { get; }

        internal decimal FutureRate { get; }

        internal DateOnly TradeDate { get; }
  
    

        internal DateTime LastUpdateTimeUtc { get; }
        internal DateTime FirstDealEntryTimeUtc { get; }

        internal DateTime LastDealEntryTimeUtc { get; }
        internal decimal AvgPrice { get; }
      
        internal FutureContract FutureContract { get; }
        internal int FutureContractId =>FutureContract.Id;
        internal decimal PointValue => FutureContract.PointValue;
        internal decimal Principal { get; }

        internal decimal TradeValue { get; }
        internal int NumberOfDeals { get; }


        internal decimal MaxDealPrice { get; }


        internal decimal MinDealPrice { get; }
        internal EfrpTrade(IEnumerable<EfrpDeal> efrpDeals)
        {
            EfrpDeals = efrpDeals;
            FutureContract = efrpDeals.Select(x => x.FutureContract).Distinct().Single();
            Exchange = efrpDeals.Select(x=>x.Exchange).Distinct().Single();
            BloombergSymbol = efrpDeals.Select(x => x.BloombergSymbol).Distinct().Single();
     
            ExchangeSymbol = efrpDeals.Select(x => x.ExchangeSymbol).Distinct().Single(); 
            ClientSide = efrpDeals.Select(x => x.DealSide).Distinct().Single(); 
            Quantity = efrpDeals.Sum(x => x.Quantity); 
            Ccy1 = efrpDeals.Select(x => x.Currency).Distinct().Single();
            Ccy1Amount = efrpDeals.Sum(x => x.ForwardAmount);
            TradeDate = efrpDeals.Select(x => x.TradeDate).Distinct().Single();
            LastUpdateTimeUtc = efrpDeals.Max(x => x.LastUpdateTimeUtc);
            FirstDealEntryTimeUtc = efrpDeals.Min(x => x.DealEntryTimeUtc);
            LastDealEntryTimeUtc = efrpDeals.Max(x => x.DealEntryTimeUtc);
            AvgPrice = efrpDeals.Sum(x=>x.DealValue)/Quantity;
            TradeValue = AvgPrice * Quantity;
            Principal = TradeValue * PointValue;
            NumberOfDeals = efrpDeals.Count();
            MaxDealPrice = efrpDeals.Max(x => x.Price);
            MinDealPrice = efrpDeals.Min(x => x.Price);
        }

        public override string? ToString()
        {
            return $"{ClientSide} {Quantity} {BloombergSymbol} {AvgPrice} {TradeDate}";
         
        }

        public override bool Equals(object? obj)
        {
            return obj is EfrpTrade aggregate &&
                   Exchange == aggregate.Exchange &&
                   BloombergSymbol == aggregate.BloombergSymbol &&
                   ExchangeSymbol == aggregate.ExchangeSymbol &&
                   ClientSide == aggregate.ClientSide &&
                   Ccy1 == aggregate.Ccy1 &&
                   TradeDate.Equals(aggregate.TradeDate);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Exchange, BloombergSymbol, ExchangeSymbol, ClientSide, Ccy1, TradeDate);
        }
    }
}
