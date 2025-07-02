using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{
    internal interface IHistoryRequest<TResponse>
    {
        CorrelationID RequestId { get; }

        Request CreateRequest(Service service);
        //IHistoryResponseHandler SendAsync(Session session, string serviceName);

        IHistoryResponseHandler CreateResponseHandler(TaskCompletionSource<HistoryResponse<TResponse>> taskCompletionSource);
    }
}
