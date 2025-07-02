using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class Instrument
    {
        internal int Id { get; }
        internal InstrumentType InstrumentType { get; }
        internal string Symbol { get; }

        internal MarketSector MarketSector { get; }
        internal string Name { get; }

        internal Currency Currency { get; }

        internal Exchange? Exchange { get; }

        public Instrument(int id, InstrumentType instrumentType, string symbol, string name, Currency currency, Exchange? exchange, MarketSector marketSector)
        {
            Id = id;
            InstrumentType = instrumentType;
            Symbol = symbol;
            Name = name;
            Currency = currency;
            Exchange = exchange;
            MarketSector = marketSector;
        }
        public Instrument(InstrumentType instrumentType, string symbol, string name, Currency currency, Exchange? exchange, MarketSector marketSector)
        {

            InstrumentType = instrumentType;
            Symbol = symbol;
            Name = name;
            Currency = currency;
            Exchange = exchange;
            MarketSector = marketSector;
        }


        internal Instrument WithId(int id)
           => new Instrument(id, InstrumentType, Symbol, Name, Currency, Exchange, MarketSector);
        
            

        internal Instrument UpdateFieldsFrom(Instrument instrument)
        {
            if (instrument.Id > 0 || instrument.Id != Id)
                throw new InvalidOperationException($"Instrument {this} can't be updated with instrument{instrument} as they don't share the same id");
            return new Instrument(Id, instrument.InstrumentType, instrument.Symbol, instrument.Name, instrument.Currency, instrument.Exchange, instrument.MarketSector);
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

        public override string? ToString()
        {
            return Symbol;
        }

        internal bool HasSameFieldsThan(Instrument instrument)
        {

            return this.Symbol == instrument.Symbol
            && this.Name == instrument.Name
           && this.Currency == instrument.Currency
           && this.Exchange == instrument.Exchange
           && this.MarketSector == instrument.MarketSector;

        }
    }
}
