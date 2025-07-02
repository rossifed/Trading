using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages
{
    internal interface IEmsxEventHandler
    {

        void HandleEvent(Event evt, Session session);

    }
    internal class EmsxEventHandler : IEmsxEventHandler
    {
        private IResponseMessageProcessor ResponseMessageProcessor { get; }
        private IMiscMessageProcessor MiscMessageProcessor { get; }
        private IServiceMessageProcessor ServiceMessageProcessor { get; }
        private ISessionMessageProcessor SessionMessageProcessor { get; }
        private ISubscriptionDataMessageProcessor SubscriptionDataMessageProcessor { get; }
        private ISubscriptionStatusMessageProcessor SubscriptionStatusMessageProcessor { get; }
        private ILogger<EmsxEventHandler> Logger { get; }


        public EmsxEventHandler(
            IResponseMessageProcessor responseMessageProcessor,
            IMiscMessageProcessor miscMessageProcessor,
            IServiceMessageProcessor serviceMessageProcessor,
            ISessionMessageProcessor sessionMessageProcessor,
            ISubscriptionDataMessageProcessor subscriptionDataMessageProcessor,
            ISubscriptionStatusMessageProcessor subscriptionStatusMessageProcessor,
            ILogger<EmsxEventHandler> logger)
        {
            ResponseMessageProcessor = responseMessageProcessor;
            MiscMessageProcessor = miscMessageProcessor;
            ServiceMessageProcessor = serviceMessageProcessor;
            SessionMessageProcessor = sessionMessageProcessor;
            SubscriptionDataMessageProcessor = subscriptionDataMessageProcessor;
            SubscriptionStatusMessageProcessor = subscriptionStatusMessageProcessor;
            Logger = logger;
        }

        public void HandleEvent(Event evt, Session session)
        {
            try
            {
                Logger.LogTrace($"Event {evt.Type} received...");
                
                switch (evt.Type)
                {
                    case Event.EventType.ADMIN:
                        SessionMessageProcessor.ProcessMessages(evt, session);
                        break;
                    case Event.EventType.SESSION_STATUS:
                        SessionMessageProcessor.ProcessMessages(evt, session);
                        break;
                    case Event.EventType.SERVICE_STATUS:
                        ServiceMessageProcessor.ProcessMessages(evt, session);
                        break;
                    case Event.EventType.RESPONSE:
                        ResponseMessageProcessor.ProcessMessages(evt, session);
                        break;
                    case Event.EventType.PARTIAL_RESPONSE:
                        ResponseMessageProcessor.ProcessPartialMessages(evt, session);
                        break;
                    case Event.EventType.SUBSCRIPTION_STATUS:
                        SubscriptionStatusMessageProcessor.ProcessMessages(evt, session);
                        break;
                    case Event.EventType.SUBSCRIPTION_DATA:
                        SubscriptionDataMessageProcessor.ProcessMessages(evt, session);
                        break;
                    default:
                        MiscMessageProcessor.ProcessMessages(evt, session);
                        break;
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"Error processing Event {evt.Type}");
            }
        }

    }
}
