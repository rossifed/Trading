using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors
{
    internal interface IResponseMessageProcessor : IMessageProcessor {
        void ProcessPartialMessages(IEnumerable<Message> messages, Session session);
        void ProcessPartialMessage(Message msg, Session session);
    };
    internal class ResponseMessageProcessor : AbstractMessageProcessor, IResponseMessageProcessor
    {
        private static readonly Name ERROR_INFO = new Name("ErrorInfo");
        private static readonly Name ERROR_RESPONSE = new Name("ErrorResponse");
        private IEnumerable<IResponseMessageHandler> ResponseMessageHandlers { get; }

        private ILogger<ResponseMessageProcessor> Logger { get; }
        public ResponseMessageProcessor(
            IEnumerable<IResponseMessageHandler> responseMessageHandlers,
            ILogger<ResponseMessageProcessor> logger
            )
        {
            ResponseMessageHandlers = responseMessageHandlers;
            Logger = logger;
        }

        public override void ProcessMessage(Message msg, Session session)
        {
            Logger.LogInformation($"Processing Message {msg.MessageType}, {msg.CorrelationID}..");
            foreach (var handler in ResponseMessageHandlers)
            {
                if (msg.MessageType.Equals(ERROR_INFO) || msg.MessageType.Equals(ERROR_RESPONSE))
                {
                    handler.OnResponseError(msg, session);
                }
                else
                {
                    handler.OnResponseMessage(msg, session);
                }
            }

        }

        public void ProcessPartialMessages(IEnumerable<Message> messages, Session session)
        {
            foreach (Message msg in messages)
            {
                ProcessPartialMessage(msg, session);
            }
        }

        public void ProcessPartialMessage(Message msg, Session session)
        {
            foreach (var handler in ResponseMessageHandlers)
            {
                if (msg.MessageType.Equals(ERROR_INFO) || msg.MessageType.Equals(ERROR_RESPONSE))
                {
                    handler.OnResponseError(msg, session);
                }
                else
                {
                    handler.OnPartialResponseMessage(msg, session);
                }
            }
        }
    }
}
