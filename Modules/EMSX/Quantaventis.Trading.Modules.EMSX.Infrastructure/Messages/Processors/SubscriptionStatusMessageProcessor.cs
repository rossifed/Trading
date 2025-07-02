using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors
{
    internal interface ISubscriptionStatusMessageProcessor : IMessageProcessor { };
    internal class SubscriptionStatusMessageProcessor : AbstractMessageProcessor, ISubscriptionStatusMessageProcessor
    {
        private static readonly Name SUBSCRIPTION_FAILURE = new Name("SubscriptionFailure");
        private static readonly Name SUBSCRIPTION_STARTED = new Name("SubscriptionStarted");
        private static readonly Name SUBSCRIPTION_TERMINATED = new Name("SubscriptionTerminated");
        private IEnumerable<ISubscriptionStatusMessageHandler> SubscriptionStatusMessageHandlers { get; }


        public SubscriptionStatusMessageProcessor(
            IEnumerable<ISubscriptionStatusMessageHandler> subscriptionStatusMessageHandlers)
        {
            SubscriptionStatusMessageHandlers = subscriptionStatusMessageHandlers;
        }

        public override void ProcessMessage(Message msg, Session session)
        {
            foreach (var handler in SubscriptionStatusMessageHandlers)
            {
                if (msg.MessageType.Equals(SUBSCRIPTION_STARTED))
                {
                    handler.OnSubscriptionStarted(msg, session);
                }
                else if (msg.MessageType.Equals(SUBSCRIPTION_FAILURE))
                {
                    handler.OnSubscriptionFailure(msg, session);
                }
                else if (msg.MessageType.Equals(SUBSCRIPTION_TERMINATED))
                {
                    handler.OnSubscriptionTerminated(msg, session);
                }
            }
        }

    }
}
