using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class EfrpDeal
    {


        internal string Exchange { get; }
        internal string BloombergSymbol { get; }
        internal string ExchangeSymbol { get; }

        internal string DealSide { get; }
        internal int Quantity { get; }

        internal string Currency { get; }

        internal decimal ForwardAmount { get; }

        internal decimal FutureRate { get; }

        internal DateOnly TradeDate { get; }
        internal DateOnly ValeDate { get; }
        internal string EntryUser { get; }

        internal DateTime LastUpdateTimeUtc { get; }
        internal DateTime DealEntryTimeUtc { get; }
        internal FutureContract FutureContract { get; }
        internal decimal Price {get;}
        internal decimal Principal { get; }

        internal decimal DealValue { get; }
        internal decimal PointValue => FutureContract.PointValue;
        public EfrpDeal(TradeAffirmFutureItem futureItem,
            FutureContract futureContract)
        {
         
            FutureContract = futureContract;
            Exchange = futureItem.Exchange;
            BloombergSymbol = futureItem.BloombergSymbol;
            ExchangeSymbol = futureItem.ExchangeSymbol;
            DealSide = futureItem.ClientSide;

            Currency = "USD"; // futureItem.Ccy1; EFRP are priced in USD in the trade affirm file
            ForwardAmount = futureItem.Ccy1Amount;
            Quantity = Math.Sign(ForwardAmount) * Math.Abs(futureItem.Quantity);
            FutureRate = futureItem.FutureRate;
            TradeDate = futureItem.TradeDate;
            Price = Math.Abs(ForwardAmount / Quantity / PointValue * FutureRate);
            DealValue = Price * Quantity;
            Principal = DealValue * PointValue;
            EntryUser = futureItem.EntryUser;
            LastUpdateTimeUtc = futureItem.LastUpdateTimeUtc;
            DealEntryTimeUtc = futureItem.DealEntryTimeUtc;
        }
       
        public override string? ToString()
        {
            return $"{Quantity} {BloombergSymbol} {FutureRate} {TradeDate}";

        }

        public override bool Equals(object? obj)
        {
            return obj is EfrpDeal deal &&
                   Exchange == deal.Exchange &&
                   BloombergSymbol == deal.BloombergSymbol &&
                   ExchangeSymbol == deal.ExchangeSymbol &&
                   DealSide == deal.DealSide &&
                   Quantity == deal.Quantity &&
                   Currency == deal.Currency &&
                   ForwardAmount == deal.ForwardAmount &&
                   FutureRate == deal.FutureRate &&
                   TradeDate.Equals(deal.TradeDate) &&
                   ValeDate.Equals(deal.ValeDate) &&
                   EntryUser == deal.EntryUser &&
                   LastUpdateTimeUtc == deal.LastUpdateTimeUtc &&
                   DealEntryTimeUtc == deal.DealEntryTimeUtc &&
                   EqualityComparer<FutureContract>.Default.Equals(FutureContract, deal.FutureContract) &&
                   Price == deal.Price &&
                   Principal == deal.Principal &&
                   DealValue == deal.DealValue &&
                   PointValue == deal.PointValue;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Exchange);
            hash.Add(BloombergSymbol);
            hash.Add(ExchangeSymbol);
            hash.Add(DealSide);
            hash.Add(Quantity);
            hash.Add(Currency);
            hash.Add(ForwardAmount);
            hash.Add(FutureRate);
            hash.Add(TradeDate);
            hash.Add(ValeDate);
            hash.Add(EntryUser);
            hash.Add(LastUpdateTimeUtc);
            hash.Add(DealEntryTimeUtc);
            hash.Add(FutureContract);
            hash.Add(Price);
            hash.Add(Principal);
            hash.Add(DealValue);
            hash.Add(PointValue);
            return hash.ToHashCode();
        }
    }
}
