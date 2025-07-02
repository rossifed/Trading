using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Options;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using System.Collections.Concurrent;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Services
{
    internal interface IHistoryRequestService : IResponseMessageHandler
    {
        Task<HistoryResponse<TResponse>> SendRequestHistoryAsync<TRequest, TResponse>(TRequest request, Session session) where TRequest : IHistoryRequest<TResponse>;
    }

    internal class HistoryRequestService : IHistoryRequestService
    {
        private string ServiceName { get; }
        private ConcurrentDictionary<CorrelationID, IHistoryResponseHandler> ResponseHandlers = new ConcurrentDictionary<CorrelationID, IHistoryResponseHandler>();
        protected ILogger<RequestResponseService> Logger { get; }

        public HistoryRequestService(EmsxApiOptions apiOptions, ILogger<RequestResponseService> logger) : this(apiOptions.HistoryServiceName, logger)
        {

        }
        public HistoryRequestService(string serviceName, ILogger<RequestResponseService> logger)
        {
            this.ServiceName = serviceName;
            Logger = logger;
        }
        private void SendRequest<TResponse>(IHistoryRequest<TResponse> request, Session session)
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

        public async Task<HistoryResponse<TResponse>> SendRequestHistoryAsync<TRequest, TResponse>(TRequest request, Session session) where TRequest : IHistoryRequest<TResponse>
        {
            TaskCompletionSource<HistoryResponse<TResponse>> completionSource = new TaskCompletionSource<HistoryResponse<TResponse>>();
            try
            {
                IHistoryResponseHandler responseHandler = request.CreateResponseHandler(completionSource);
                if (ResponseHandlers.TryAdd(request.RequestId, responseHandler))
                {
                    SendRequest<TResponse>(request, session);
                }
                else
                {
                    var errorMsg = $"HistoryResponseHandler couldn't be added into dictionary for RequestId{request.RequestId}";
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
            if (ResponseHandlers.TryGetValue(msg.CorrelationID, out var handler))
            {
                Logger.LogError($"History Response Error: MessageType:{msg.MessageType}, CorrelationID:{msg.CorrelationID}");
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

            if (ResponseHandlers.TryGetValue(msg.CorrelationID, out var handler))
            {
                handler.HandlePartial(msg);
            }
        }
    }

}
