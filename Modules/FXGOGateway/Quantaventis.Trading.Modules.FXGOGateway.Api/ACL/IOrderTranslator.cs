using Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.ACL
{
    internal interface IOrderTranslator<T>
    {

        FxemOrder Translate(T order);

        IEnumerable<FxemOrder> Translate(IEnumerable<T> orders);
    }
}
