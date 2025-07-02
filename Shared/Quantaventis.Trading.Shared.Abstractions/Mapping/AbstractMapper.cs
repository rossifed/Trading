using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Abstractions.Mapping
{
    public abstract class AbstractMapper<TSource, TTarget> : IMapper<TSource, TTarget>
    {
        public abstract TTarget Map(TSource source);

        public IEnumerable<TTarget> Map(IEnumerable<TSource> sources)
         => sources.Select(x => Map(x));
    }
}
