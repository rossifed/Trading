using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Options;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using System.Collections.Concurrent;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Services
{
    internal interface IRequestResponseService : IResponseMessageHandler
    {
        Task<TResponse> SendRequestAsync<TRequest, TResponse>(TRequest request, Session session) where TRequest : IRequest<TResponse>;

    }

    internal class RequestResponseService : IRequestResponseService
    {
        private string ServiceName { get; }
        private ConcurrentDictionary<CorrelationID, IResponseHandler> ResponseHandlers = new ConcurrentDictionary<CorrelationID, IResponseHandler>();
        protected ILogger<RequestResponseService> Logger { get; }

        public RequestResponseService(
        EmsxApiOptions apiOptions,
            ILogger<RequestResponseService> logger) : this(apiOptions.ServiceName, logger)
        {

        }
        public RequestResponseService(
         string serviceName,
          ILogger<RequestResponseService> logger)
        {
            this.ServiceName = serviceName;
            Logger = logger;
        }


        private void SendRequest<TResponse>(IRequest<TResponse> request, Session session)
        {
            try
            {
                var emsxRequest = request.CreateRequest(session.GetService(ServiceName));
                session.SendRequest(emsxRequest, request.RequestId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error sending Request: {request}");
                throw;
            }
        }

        public async Task<TResponse> SendRequestAsync<TRequest, TResponse>(TRequest request, Session session) where TRequest : IRequest<TResponse>
        {
            TaskCompletionSource<TResponse> completionSource = new TaskCompletionSource<TResponse>();
            try
            {
                IResponseHandler responseHandler = request.CreateResponseHandler(completionSource);
                if (ResponseHandlers.TryAdd(request.RequestId, responseHandler))
                {
                    SendRequest<TResponse>(request, session);
                }
                else
                {
                    var errorMsg = $"ResponseHandler couldn't be added into dictionary for RequestId{request.RequestId}";
                    Logger.LogError(errorMsg);
                    throw new InvalidOperationException(errorMsg);
                }
            }
            catch (Exception ex)
            {
                completionSource.SetException(ex);
            }
            return await completionSource.Task;
        }

        public void OnResponseError(Message msg, Session session)
        {
            if (ResponseHandlers.TryRemove(msg.CorrelationID, out var handler))
            {
                Logger.LogError($"Error message received MessageType:{msg.MessageType}, CorrelationID{msg.CorrelationID}");
                handler.HandleError(msg);
            }
        }

        public void OnResponseMessage(Message msg, Session session)
        {
            if (ResponseHandlers.TryRemove(msg.CorrelationID, out var handler))
            {
                handler.Handle(msg);
            }
        }

        public void OnPartialResponseMessage(Message msg, Session session)
        {
            //Partial resposne only used by History service. 
        }
    }

}
