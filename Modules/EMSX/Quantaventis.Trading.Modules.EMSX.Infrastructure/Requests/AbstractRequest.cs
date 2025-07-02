using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    public abstract class AbstracRequest<TResponse> : IRequest<TResponse>
    {

        public CorrelationID RequestId { get; }
        public string RequestType { get; }


        public AbstracRequest(string requestType)
        {
            RequestType = requestType;
       
            RequestId = new CorrelationID();

        }
    
        public Request CreateRequest(Service service)
        {
            Request emsxRequest = service.CreateRequest(RequestType);
            return BuildRequest(emsxRequest);
        }
        protected abstract Request BuildRequest(Request request);


        public async Task<TResponse> SendAsync(Session session, string serviceName)
        {
            TaskCompletionSource<TResponse> completionSource = new TaskCompletionSource<TResponse>();
            IResponseHandler responseHandler = CreateResponseHandler(completionSource);
            var emsxRequest = CreateRequest(session.GetService(serviceName));
            session.SendRequest(emsxRequest, RequestId);
            return await completionSource.Task;
        }

        public override string? ToString()
        {
            return $"{RequestType}: {RequestId}";
        }

        public abstract IResponseHandler CreateResponseHandler(TaskCompletionSource<TResponse> taskCompletionSource);
        
    }
}
