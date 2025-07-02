using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Dispatchers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions
{
    internal interface ISubscription
    {
        CorrelationID SubscriptionId { get; }
        void Start(Session session, string serviceName, string teamName);
        void Start(Session session, string serviceName);
        void Cancel(Session session);

        bool Match(Message message);

 

    }
}
