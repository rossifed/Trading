using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors
{
    internal interface IServiceMessageProcessor : IMessageProcessor { };
    internal class ServiceMessageProcessor : AbstractMessageProcessor, IServiceMessageProcessor
    {
        private static readonly Name SERVICE_OPENED = new Name("ServiceOpened");
        private static readonly Name SERVICE_OPEN_FAILURE = new Name("ServiceOpenFailure");

        private IEnumerable<IServiceMessageHandler> ServiceMessageHandlers { get; }


        public ServiceMessageProcessor(
            IEnumerable<IServiceMessageHandler> serviceMessageHandlers)
        {
            ServiceMessageHandlers = serviceMessageHandlers;
        }


        public override void ProcessMessage(Message msg, Session session)
        {
            foreach (var handler in ServiceMessageHandlers)
            {
                if (msg.MessageType.Equals(SERVICE_OPENED))
                {
                    handler.OnServiceOpened(msg, session);

                }
                else if (msg.MessageType.Equals(SERVICE_OPEN_FAILURE))
                {
                    handler.OnServiceOpenFailure(msg, session);

                }
            }
        }
    }
}
