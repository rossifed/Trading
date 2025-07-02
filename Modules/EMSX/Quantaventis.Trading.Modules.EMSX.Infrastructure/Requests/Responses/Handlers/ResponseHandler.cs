using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;
using static Bloomberglp.Blpapi.SubscriptionPreprocessError;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers
{
    public interface IResponseHandler
    {
        void Handle(Message msg);
        void HandleError(Message msg);


    }


    internal  class ResponseHandler<TRequest, TResponse> : IResponseHandler
    {

        public string MessageType { get; }

        public CorrelationID CorrelationID { get; }

        private TaskCompletionSource<TResponse> TaskCompletionSource { get; }
        private IMessageParser<TResponse> ResponseParser { get; }

        public ResponseHandler(string messageType,
            CorrelationID correlationID,
            IMessageParser<TResponse> responseParser,
            TaskCompletionSource<TResponse> taskCompletionSource)
        {
            CorrelationID   = correlationID;
            MessageType = messageType;
            ResponseParser = responseParser;
            TaskCompletionSource = taskCompletionSource;
        }

        public void HandleError(Message msg) {
            int errorCode = msg.GetAsIntOrDefault(ERROR_CODE, -1);
            string errorMessage = msg.GetAsStringOrDefault(ERROR_MESSAGE, "");     
            TaskCompletionSource.SetException(new Exception($"ERROR CODE: {errorCode}\tERROR MESSAGE: {errorMessage}"));
        }

        public void Handle(Message msg) {
            if (msg.MessageType.Equals(MessageType))
            {

                if (msg.CorrelationID == CorrelationID)
                {
                    try
                    {
                        TResponse response = ResponseParser.Parse(msg);
                        TaskCompletionSource.SetResult(response);
                    }
                    catch (Exception ex)
                    {
        
                        TaskCompletionSource.SetException(ex);
                    }
                }
                else
                {
                    var errmsg = ($"Message CorrelationID:{msg.CorrelationID} doesn't match handler CorrelationID{CorrelationID}");
                    throw new InvalidOperationException( errmsg );
                }
            }
            else
            {
                var errmsg = ($"Message Type {msg.MessageType} is not supported. Expecting Message of type {MessageType}");
                throw new InvalidOperationException(errmsg);

            }

        }
    }
}
