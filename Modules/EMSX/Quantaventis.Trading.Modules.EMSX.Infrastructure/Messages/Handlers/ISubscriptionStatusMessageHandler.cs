using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers
{
    internal interface ISubscriptionStatusMessageHandler
    {
        void OnSubscriptionStarted(Message msg, Session session);

        void OnSubscriptionTerminated(Message msg, Session session);

        void OnSubscriptionFailure(Message msg, Session session);
    }
}
