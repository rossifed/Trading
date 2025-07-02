using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    internal static class Extensions
    {

       internal static IEnumerable<int> GetSequences(this IEnumerable<EmsxOrder> orders )
            => orders.Select( x => x.Sequence).ToList();

        internal static IEnumerable<string> GetOrderRefIds(this IEnumerable<EmsxOrder> orders)
          => orders.Select(x => x.OrderRefId).ToList();

    }
}
