using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class EfrpOrder
    {
        internal Currency BaseCurrency { get; }

        internal Currency QuoteCurrency { get; }

        internal DateOnly MaturityDate { get; }

        internal int Quantity { get; }


    }
}
