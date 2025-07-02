using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class FxForward
    {
        internal int Id { get; }
        internal int CurrencyPairId { get; }
        internal Instrument Instrument { get; }
        internal CurrencyPair CurrencyPair { get; }
        internal Currency BaseCurrency => CurrencyPair.BaseCurrency;
        internal Currency QuoteCurrency => CurrencyPair.QuoteCurrency;
        internal DateOnly MaturityDate { get; }
        internal string Symbol => Instrument.Symbol;
        internal FxForward(Instrument instrument, int CurrencyPairId, CurrencyPair currencyPair, DateOnly maturityDate)
        {
            Id = instrument.Id;
            Instrument = instrument;
            CurrencyPair = currencyPair;
            MaturityDate = maturityDate;
            CurrencyPairId = CurrencyPairId;
        }
        internal FxForward WithId(int id)
            => new FxForward(Instrument.WithId(id), CurrencyPairId, CurrencyPair, MaturityDate);
        public override bool Equals(object? obj)
        {
            return obj is FxForward forward &&
                   Id == forward.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return Instrument.ToString();
        }

        internal FxForward UpdateFieldsFrom(FxForward FxForward)
        {
            return new FxForward(Instrument.UpdateFieldsFrom(FxForward.Instrument), CurrencyPairId, FxForward.CurrencyPair, FxForward.MaturityDate);
        }

        internal bool HasSameFieldsThan(FxForward FxForward)
        {
            return this.Instrument.HasSameFieldsThan(FxForward.Instrument)
                && MaturityDate == FxForward.MaturityDate;
        }
    }
}
