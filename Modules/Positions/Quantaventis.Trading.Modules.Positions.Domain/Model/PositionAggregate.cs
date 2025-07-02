using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Positions.Domain.Model
{
    internal class PositionAggregate
    {
        internal class PositionAggregateId
        {
            internal byte  PortfolioId{get;}

            internal int InstrumentId { get; }

            internal bool IsSwap { get; }

            public override bool Equals(object? obj)
            {
                return obj is PositionAggregateId id &&
                       PortfolioId == id.PortfolioId &&
                       InstrumentId == id.InstrumentId &&
                       IsSwap == id.IsSwap;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(PortfolioId, InstrumentId, IsSwap);
            }
        }
        internal PositionAggregateId Id { get; }


        IEnumerable<Position> Positions { get; }
    }
}
