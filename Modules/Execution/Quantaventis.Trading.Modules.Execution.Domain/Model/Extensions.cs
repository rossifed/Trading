using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Execution.Domain.Model
{
    internal static class Extensions
    {

        internal static T Single<T>(this IEnumerable<EmsxFill> emsxFills, Func<EmsxFill, T> expression)
        {
            return emsxFills.Select(expression).Distinct().Single();
        }


        internal static T? SingleOrDefault<T>(this IEnumerable<EmsxFill> emsxFills, Func<EmsxFill, T> expression)
        {
            return emsxFills.Select(expression).Distinct().SingleOrDefault();
        }
        internal static T? Max<T>(this IEnumerable<EmsxFill> emsxFills, Func<EmsxFill, T> expression)
        {
            return emsxFills.Select(expression).Max();
        }
        internal static T? Min<T>(this IEnumerable<EmsxFill> emsxFills, Func<EmsxFill, T> expression)
        {
            return emsxFills.Select(expression).Min();
        }

        internal static decimal ComputeAveragePrice(this IEnumerable<EmsxFill> emsxFills)
        {
            return emsxFills.Sum(x => (x.FillPrice * x.FillShares)) / emsxFills.Sum(x => (x.FillShares));
        }

    }
}
