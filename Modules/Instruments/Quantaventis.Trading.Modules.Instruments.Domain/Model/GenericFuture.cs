using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class GenericFuture
    {
        internal string Symbol => Instrument.Symbol;
        internal int Id => Instrument.Id;
        internal Instrument Instrument { get; }
        internal double ContractSize { get; }
        internal FutureTick FutureTick { get; }
        internal string RootSymbol { get; }

        internal double PointValue => FutureTick.PointValue;
        internal double TickSize => FutureTick.TickSize;
        internal double TickValue => FutureTick.TickValue;
        internal MarketSector MarketSector => Instrument.MarketSector;

        internal GenericFuture(
            Instrument instrument,
            string rootSymbol,
            double contractSize,
            FutureTick futureTick)
        {
            Instrument = instrument;
            RootSymbol = rootSymbol;
            ContractSize = contractSize;
            FutureTick = futureTick;
        }

        internal GenericFuture WithId(int id)
             => new GenericFuture(Instrument.WithId(id), RootSymbol, ContractSize, FutureTick);


        internal GenericFuture UpdateFieldsFrom(GenericFuture genericFuture)
        {

            return new GenericFuture(
                Instrument.UpdateFieldsFrom(genericFuture.Instrument),
                genericFuture.RootSymbol,
                genericFuture.ContractSize,
                genericFuture.FutureTick);
        }

        internal bool HasSameFieldsThan(GenericFuture genericFuture)
        {
            return this.Instrument.HasSameFieldsThan(genericFuture.Instrument)
                && this.FutureTick.Equals(genericFuture.FutureTick)
                && this.ContractSize == genericFuture.ContractSize
                && this.RootSymbol == genericFuture.RootSymbol;
        }

        public override bool Equals(object? obj)
        {
            return obj is GenericFuture future &&
                   Id == future.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
