using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Parsers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Dispatchers
{
    interface ISubscriptionMessageDispatcher
    {
        void DispatchInitialPaintEnd(Message message);
        void DispatchSubscriptionMessage(Message message);

    }

    internal class SubscriptionMessageDispatcher<TSubscription, TMessage> : ISubscriptionMessageDispatcher where TMessage : ISubscriptionMessage where TSubscription : ISubscription
    {


        private InitialPaint InitialPaint { get; }

        private ISubscriptionMessageParser<TMessage> SubscriptionMessageParser { get; }
        private ISubscriptionMessageHandler<TMessage> SubscriptionMessageHandler { get; }

        protected TSubscription Subscription { get; }

        protected SubscriptionMessageDispatcher(
            TSubscription subscription,
            ISubscriptionMessageParser<TMessage> subscriptionMessageParser,
            ISubscriptionMessageHandler<TMessage> subscriptionMessageHandler)
        {
            InitialPaint = new InitialPaint();
            Subscription = subscription;
            SubscriptionMessageParser = subscriptionMessageParser;
            SubscriptionMessageHandler = subscriptionMessageHandler;
        }


        public void DispatchInitialPaintEnd(Message message)
        {
            if (Subscription.Match(message))
            {
                InitialPaint.AddMessage(message);
                InitialPaint.End();
                IEnumerable<TMessage> initialPaintMessages = InitialPaint
                    .GetMessages()
                    .Select(msg => SubscriptionMessageParser.Parse(msg))
                    .ToList();
                Task.Run(() =>
                     SubscriptionMessageHandler.OnInitialPaintEndAsync(initialPaintMessages));
            }
        }

        public void DispatchSubscriptionMessage(Message message)
        {
            if (Subscription.Match(message))
            {
                if (InitialPaint.IsEnded)
                {
                    TMessage parsedMessage = SubscriptionMessageParser.Parse(message);
                    Task.Run(() =>
                     SubscriptionMessageHandler.OnSubscriptionMessageAsync(parsedMessage));
                }

                else
                {
                    InitialPaint.AddMessage(message);
                }
            }
        }

    }
}
