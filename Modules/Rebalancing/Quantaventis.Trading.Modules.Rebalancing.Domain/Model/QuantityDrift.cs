using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class QuantityDrift
    {
        internal Quantity CurrentQuantity { get; private set; }
        internal Quantity TargetQuantity { get; private set; }
        internal Quantity Amount { get; private set; }

        public QuantityDrift(Quantity currentQuantity, Quantity targetQuantity)
        {
            CurrentQuantity = currentQuantity;
            TargetQuantity = targetQuantity;
            Amount = TargetQuantity - CurrentQuantity;
        }
        internal bool IsZero() => Amount == 0;
        public override string? ToString()
        {
            return $"{Amount}";
        }
    }
}
