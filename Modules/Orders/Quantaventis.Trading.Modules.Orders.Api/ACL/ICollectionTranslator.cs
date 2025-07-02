using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.ACL
{
    internal interface ICollectionTranslator<T,S>
    {
        Task<IEnumerable<S>> TranslateAsync(IEnumerable<T> translate);

    }
}
