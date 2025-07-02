using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses.Parsers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using static Bloomberglp.Blpapi.SubscriptionPreprocessError;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses.Handlers
{
    public interface IHistoryResponseHandler
    {
        void HandlePartial(Message msg);
        void Handle(Message msg);
        void HandleError(Message errorMessage);
    }


    internal class HistoryResponseHandler<TRequest, TResponse> : IHistoryResponseHandler
    {

        public string MessageType { get; }

        public CorrelationID CorrelationID { get; }
        private ConcurrentQueue<TResponse> PartialMessages { get; } = new ConcurrentQueue<TResponse>();
        private TaskCompletionSource<HistoryResponse<TResponse>> TaskCompletionSource { get; }
        private IMessageParser<TResponse> ResponseParser { get; }

        public HistoryResponseHandler(string messageType,
            CorrelationID correlationID,
            IMessageParser<TResponse> responseParser,
            TaskCompletionSource<HistoryResponse<TResponse>> taskCompletionSource)
        {
            CorrelationID = correlationID;
            MessageType = messageType;
            ResponseParser = responseParser;
            TaskCompletionSource = taskCompletionSource;
        }

        public void HandleError(Message msg)
        {
            string errorCode = msg.GetElementAsString("ErrorCode");
            string errorMessage = msg.GetElementAsString("ErrorMsg");

            string errorMessages = $"ERROR CODE: {errorCode}\tERROR MESSAGE: {errorMessage}";
            TaskCompletionSource.SetException(new Exception(errorMessage));
        }

        public void Handle(Message msg)
        {
            CheckAndHandle(msg, msg =>
                    {
                        TResponse response = ResponseParser.Parse(msg);
                        PartialMessages.Enqueue(response);
                        HistoryResponse<TResponse> historyResponse = new HistoryResponse<TResponse>(PartialMessages.ToImmutableList());
                        PartialMessages.Clear();
                        TaskCompletionSource.SetResult(historyResponse);
                    });

        }

        public void CheckAndHandle(Message msg, Action<Message> handlerChecked)
        {
            if (msg.MessageType.Equals(MessageType))
            {

                if (msg.CorrelationID == CorrelationID)
                {
                    try
                    {
                        handlerChecked(msg);
                    }
                    catch (Exception ex)
                    {

                        TaskCompletionSource.SetException(ex);
                    }
                }
                else
                {
                    var errmsg = $"Message CorrelationID:{msg.CorrelationID} doesn't match handler CorrelationID{CorrelationID}";
                    throw new InvalidOperationException(errmsg);
                }
            }
            else
            {
                var errmsg = $"Message Type {msg.MessageType} is not supported. Expecting Message of type {MessageType}";
                throw new InvalidOperationException(errmsg);

            }

        }


        public void HandlePartial(Message msg)
        {
            CheckAndHandle(msg, msg =>
            {
                TResponse response = ResponseParser.Parse(msg);
                PartialMessages.Enqueue(response);

            });
        }
    }
}
