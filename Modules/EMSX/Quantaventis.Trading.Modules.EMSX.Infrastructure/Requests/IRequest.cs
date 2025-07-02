using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    internal interface IRequest<TResponse>
    {
        CorrelationID RequestId { get; }

        Request CreateRequest(Service service);


        IResponseHandler CreateResponseHandler(TaskCompletionSource<TResponse> taskCompletionSource);
    }
}
