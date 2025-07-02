using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Model
{
    internal class TradeAffirmFutureItem
    {
        internal string Exchange { get; }
        internal string BloombergSymbol { get; }
        internal string ExchangeSymbol { get; }

        internal string ClientSide { get; }
        internal int Quantity { get; }

        internal string Ccy1 { get; }

        internal decimal Ccy1Amount { get; }

        internal decimal FutureRate { get; }

        internal DateOnly TradeDate { get; }
        internal DateOnly ValeDate { get; }
        internal string EntryUser { get; }

        internal DateTime LastUpdateTimeUtc { get; }
        internal DateTime DealEntryTimeUtc { get; }

        public TradeAffirmFutureItem(
            string exchange, 
            string bloombergSymbol, 
            string exchangeSymbol, 
            string clientSide, 
            int quantity, 
            string ccy1, 
            decimal ccy1Amount, 
            decimal futureRate, 
            DateOnly tradeDate,
            string entryUser, 
            DateTime lastUpdateTimeUtc, 
            DateTime dealEntryTimeUtc)
        {
       
            Exchange = exchange;
            BloombergSymbol = bloombergSymbol.Contains("Curncy")? bloombergSymbol:bloombergSymbol+" Curncy";
            ExchangeSymbol = exchangeSymbol;
            ClientSide = clientSide;
            Quantity = Math.Sign(ccy1Amount)*Math.Abs(quantity);
            Ccy1 = ccy1;
            Ccy1Amount = ccy1Amount;
            FutureRate = futureRate;
            TradeDate = tradeDate;           
            EntryUser = entryUser;
            LastUpdateTimeUtc = lastUpdateTimeUtc;
            DealEntryTimeUtc = dealEntryTimeUtc;
        }


        internal EfrpDeal ToEfrpDeal(Func<string, FutureContract> futureContractLookup)
             => new EfrpDeal(this, futureContractLookup(BloombergSymbol));
    }
}
