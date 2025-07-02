using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class Instrument
    {
        internal int Id { get; }
        internal string Symbol { get; }
        internal InstrumentType InstrumentType { get; }

        internal Exchange? Exchange { get; }
        internal DateOnly? Maturity { get; }
        internal int? GenericFutureId {get;}
        public Instrument(int id,
            string symbol,
            InstrumentType instrumentType,
            Exchange? exchange,
            DateOnly? maturity,
            int? genericFutureId)
        {
            Id = id;
            this.Symbol = symbol;
            this.InstrumentType = instrumentType;
            this.Exchange = exchange;
            this.Maturity = maturity;
            GenericFutureId = genericFutureId;
        }
        internal bool IsParentOf(Instrument instrument)
            =>Id == instrument.GenericFutureId;
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
            => Symbol;
    }
}
