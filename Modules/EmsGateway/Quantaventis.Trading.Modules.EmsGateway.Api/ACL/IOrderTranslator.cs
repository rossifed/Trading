using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.ACL
{
    internal interface IOrderTanslator<T,S>
    {

        S Translate(T order);

        IEnumerable<S> Translate(IEnumerable<T> orders);
    }
}
