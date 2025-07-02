using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class PositionDrift
    {
        internal Instrument Instrument { get; }
        internal TargetPosition TargetPosition { get; }
        internal InvestedPosition InvestedPosition { get; }
        internal QuantityDrift QuantityDrift { get; }

        internal WeightDrift WeightDrift { get; }

        public PositionDrift( InvestedPosition investedPosition, TargetPosition targetPosition)
        {
            if (!targetPosition.Instrument.Equals(investedPosition.Instrument))
                throw new ArgumentException("Instrument mismatch between invested position and target position");
            Instrument= targetPosition.Instrument;
            TargetPosition = targetPosition;
            InvestedPosition = investedPosition;
            QuantityDrift = new QuantityDrift(investedPosition.Quantity, targetPosition.Quantity);
            WeightDrift = new WeightDrift(investedPosition.Weight, targetPosition.Weight);
        }
        internal static PositionDrift FromFlatInvestedPosition(TargetPosition targetWeight)
            => new PositionDrift(InvestedPosition.Flat(targetWeight.Instrument), targetWeight);
        internal static PositionDrift FromFlatTargetPosition(InvestedPosition position)
           => new PositionDrift(position, TargetPosition.Flat(position.Instrument));
        internal PositionDrift Update(TargetPosition targetWeight) {
            return new PositionDrift(InvestedPosition, targetWeight);
        }

        internal PositionDrift Update(InvestedPosition position)
        {
            return new PositionDrift(position, TargetPosition);
        }

  
        public override string? ToString()
        {
            return $"{Instrument.ToString()} {QuantityDrift}";
        }

        public override bool Equals(object? obj)
        {
            return obj is PositionDrift drift &&
                   EqualityComparer<Instrument>.Default.Equals(Instrument, drift.Instrument);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Instrument);
        }
    }
}
