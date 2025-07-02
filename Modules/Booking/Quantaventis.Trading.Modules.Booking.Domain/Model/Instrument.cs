using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class Instrument
    {
        internal int Id { get; }
        internal string Symbol { get; }
        internal decimal ContractMultiplier { get; }
        internal string MarketSector { get; }
        internal string InstrumentType { get; }
        internal bool IsFuture => InstrumentType == "FUT";
        internal decimal? FuturePointValue { get; }
        internal bool IsEquity => InstrumentType == "EQU";
        internal int? GenericFutureId { get; }
        internal string Name { get; }

        internal decimal PriceScalingFactor { get; }
        public Instrument(int instrumentId, 
            string symbol,
            string name,
            decimal? futurePointValue, 
            string instrumentType,
            string marketSector,
            int? genericFutureId,
            decimal priceScalingFactor)
        {
            Id = instrumentId;
            Symbol = symbol;
            Name = name;
            FuturePointValue = futurePointValue;
            InstrumentType = instrumentType;
            GenericFutureId = genericFutureId;
            this.MarketSector = marketSector;
            this.ContractMultiplier = futurePointValue.GetValueOrDefault(1);
            this.PriceScalingFactor = priceScalingFactor;
        }

        public override string? ToString()
        {
            return Symbol;
        }

        public override bool Equals(object? obj)
        {
            return obj is Instrument instrument &&
                   Id == instrument.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
