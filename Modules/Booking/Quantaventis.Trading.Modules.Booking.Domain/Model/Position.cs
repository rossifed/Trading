using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class Position
    {

        internal int InstrumentId { get; }

        internal Quantity Quantity { get; }
        internal bool IsSwap { get; }

        internal DateOnly PositionDate { get; }
        public Position(int instrumentId, Quantity quantity, bool isSwap, DateOnly positionDate)
        {
            InstrumentId = instrumentId;
            Quantity = quantity;
            this.IsSwap = isSwap;
            PositionDate = positionDate;
        }

        //internal static Position Flat(int instrumentId,bool isSwap, Position)
        //    => new Position(instrumentId, 0,isSwap);
        internal PositionSide ComputePositionSide(RawTradeAllocation tradeAllocation)
        {

            return ComputePositionSide(tradeAllocation.Quantity);

        }
        PositionSide ComputePositionSide(Quantity quantity) {

            decimal targetQuantity = Quantity + quantity;
            if (targetQuantity > 0)
                return PositionSide.L;
            else if (targetQuantity < 0)
                return PositionSide.S;
            else 
                return PositionSide.C;

        }

        public override string? ToString()
        {
            return $"{InstrumentId} {IsSwap} {Quantity} {PositionDate}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   InstrumentId == position.InstrumentId &&
                   EqualityComparer<Quantity>.Default.Equals(Quantity, position.Quantity) &&
                   IsSwap == position.IsSwap &&
                   PositionDate.Equals(position.PositionDate);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(InstrumentId, Quantity, IsSwap, PositionDate);
        }
    }
}
