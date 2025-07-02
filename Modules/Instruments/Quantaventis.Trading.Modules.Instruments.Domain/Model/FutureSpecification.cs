using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class FutureSpecification
    {
        internal int Id { get; }

        internal string RootSymbol { get; }

        internal string Name { get; }

        internal MarketSector MarketSector { get; }

        internal Currency Currency { get; }

        internal double ContractSize { get; }
        internal FutureTick FutureTick { get; }
        internal double PointValue => FutureTick.PointValue;
        internal double TickSize => FutureTick.TickSize;
        internal double TickValue => FutureTick.TickValue;
        public FutureSpecification(
        string rootSymbol,
        string name,
        MarketSector marketSector,
        Currency currency,
        double contractSize,
        FutureTick futureTick) : this(0, rootSymbol, name, marketSector, currency, contractSize, futureTick) { }
        public FutureSpecification(int id,
            string rootSymbol,
            string name,
            MarketSector marketSector,
            Currency currency,
            double contractSize,
            FutureTick futureTick)
        {
            Id = id;
            RootSymbol = rootSymbol;
            Name = name;
            MarketSector = marketSector;
            Currency = currency;
            ContractSize = contractSize;
            FutureTick = futureTick;

        }
        internal FutureSpecification UpdateId(int id)
        {
            if (id < 0 || id != Id)
                throw new InvalidOperationException($"FutureSpecification Id{this} can't be updated. The provided Id must greater than zero and current FutureSpecification must not have any Id yet. Provided Id:{id}, Current Specification Id:{Id}");
            return new FutureSpecification(id,
                RootSymbol,
                Name,
                MarketSector,
               Currency,
                ContractSize,
                FutureTick);
        }
        internal FutureSpecification UpdateFieldsFrom(FutureSpecification futureSpecification)
        {
            if (futureSpecification.Id > 0 || futureSpecification.Id != Id)
                throw new InvalidOperationException($"FutureSpecification {this} can't be updated with FutureSpecification{futureSpecification} as they don't share the same id");
            return new FutureSpecification(Id,
                futureSpecification.RootSymbol,
                futureSpecification.Name,
                futureSpecification.MarketSector,
                futureSpecification.Currency,
                futureSpecification.ContractSize,
                futureSpecification.FutureTick);
        }

        internal bool HasSameFieldsThan(FutureSpecification futureSpecification)
        {
            return RootSymbol == futureSpecification.RootSymbol
                && Name == futureSpecification.Name
                && MarketSector == futureSpecification.MarketSector
                && Currency == futureSpecification.Currency
                && ContractSize == futureSpecification.ContractSize
                && FutureTick == futureSpecification.FutureTick;
        }
        public override bool Equals(object? obj)
        {
            return obj is FutureSpecification specification &&
                   RootSymbol == specification.RootSymbol &&
                   EqualityComparer<MarketSector>.Default.Equals(MarketSector, specification.MarketSector);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RootSymbol, MarketSector);
        }
    }
}
