using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Api.Dto
{
    public class EfrpDealDto
    {
        public string DealId { get; set; }
        public string Exchange { get; set; }
        public string BloombergSymbol { get; set; }
        public string ExchangeSymbol { get; set; }

        public string DealSide { get; set; }
        public int Quantity { get; set; }

        public string Ccy1 { get; set; }

        public decimal Ccy1Amount { get; set; }

        public decimal FutureRate { get; set; }

        public DateOnly TradeDate { get; set; }
        public DateOnly ValeDate { get; set; }
        public string EntryUser { get; set; }

        public DateTime LastUpdateTimeUtc { get; set; }
        public DateTime DealEntryTimeUtc { get; set; }

        public decimal Price { get; set; }
        public decimal Principal { get; set; }

        public decimal DealValue { get; set; }
        public decimal PointValue { get; set; }


    }
}
