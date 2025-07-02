using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class Equity
    {
        internal int Id => Instrument.Id;
        internal Instrument Instrument { get; }
        internal string Symbol => Instrument.Symbol;
        internal Equity(Instrument instrument)
        {
            this.Instrument = instrument;
        }

        internal Equity WithId(int id) => new Equity(Instrument.WithId(id));
        internal Equity UpdateFieldsFrom(Equity equity) {
            return new Equity(Instrument.UpdateFieldsFrom(equity.Instrument));
        }

        internal bool HasSameFieldsThan(Equity equity)
        {
            return this.Instrument.HasSameFieldsThan(equity.Instrument);
        }
    }
}
