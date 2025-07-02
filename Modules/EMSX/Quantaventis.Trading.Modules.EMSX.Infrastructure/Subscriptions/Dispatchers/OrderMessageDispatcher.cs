using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Parsers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Dispatchers
{

    internal class OrderMessageDispatcher : SubscriptionMessageDispatcher<OrderSubscription, OrderSubscriptionMessage>
    {
        public OrderMessageDispatcher(
              OrderSubscription subscription,
            ISubscriptionMessageParser<OrderSubscriptionMessage> subscriptionMessageParser,
            ISubscriptionMessageHandler<OrderSubscriptionMessage> subscriptionMessageHandler
            )
            : base(subscription, subscriptionMessageParser, subscriptionMessageHandler)
        {

        }

        public OrderMessageDispatcher(
        OrderSubscription subscription,
        ISubscriptionMessageHandler<OrderSubscriptionMessage> subscriptionMessageHandler


        )
        : base(subscription, new OrderMessageParser(), subscriptionMessageHandler)
        {

        }

    }
}
