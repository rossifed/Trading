using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Abstractions.Mapping
{
    public interface IMapper<TSource, TTarget>
    {

        TTarget Map(TSource source);

        IEnumerable<TTarget> Map(IEnumerable<TSource> sources);
    }
}
