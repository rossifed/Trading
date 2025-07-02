using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class WeightDrift
    {
        internal Weight CurrentWeight { get; private set; }
        internal Weight TargetWeight { get; private set; }
        internal Weight Amount { get; private set; }

        public WeightDrift(Weight currentWeight, Weight targetWeight)
        {
            CurrentWeight = currentWeight;
            TargetWeight = targetWeight;
            Amount = TargetWeight - CurrentWeight;
        }

        internal static WeightDrift CurrentOnly(Weight currentWeight)
            => new WeightDrift(currentWeight, 0);
        internal static WeightDrift TargetOnly(Weight targetWeight)
      => new WeightDrift(0, targetWeight);
        internal WeightDrift UpdateCurrentWeight(Weight currentWeight)
            => new WeightDrift(currentWeight, TargetWeight);

        internal WeightDrift UpdateTargetWeight(Weight targetWeight)
            => new WeightDrift(CurrentWeight, targetWeight);

        public override string? ToString()
        {
            return Amount.ToString();
        }
    }
}
