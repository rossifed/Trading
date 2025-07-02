using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Parsers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Dispatchers
{


    internal class RouteMessageDispatcher : SubscriptionMessageDispatcher<RouteSubscription, RouteSubscriptionMessage>
    {
        public RouteMessageDispatcher(
            RouteSubscription subscription,
            ISubscriptionMessageParser<RouteSubscriptionMessage> subscriptionMessageParser,
            ISubscriptionMessageHandler<RouteSubscriptionMessage> subscriptionMessageHandler
            )
            : base(subscription, subscriptionMessageParser, subscriptionMessageHandler)
        {

        }

        public RouteMessageDispatcher(
        RouteSubscription subscription,
        ISubscriptionMessageHandler<RouteSubscriptionMessage> subscriptionMessageHandler


        )
        : base(subscription, new RouteMessageParser(), subscriptionMessageHandler)
        {

        }




    }
}
