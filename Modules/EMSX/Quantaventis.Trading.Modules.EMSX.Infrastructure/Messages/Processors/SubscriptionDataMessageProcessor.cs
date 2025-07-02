using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors
{
    internal interface ISubscriptionDataMessageProcessor : IMessageProcessor { };
    internal class SubscriptionDataMessageProcessor : AbstractMessageProcessor, ISubscriptionDataMessageProcessor
    {
        public const int HeartBeat = 1;
        public const int InitialPaint = 4;
        public const int NewOrderRoute = 6;
        public const int OrderRouteUpdate = 7;
        public const int OrderRouteDeletion = 8;
        public const int InitialPaintEnd = 11;
        private static readonly Name ORDER_ROUTE_FIELDS = new Name("OrderRouteFields");

        private static readonly Name EVENT_STATUS = new Name("EVENT_STATUS");
        private IEnumerable<ISubscriptionDataMessageHandler> SubscriptionDataMessageHandlers { get; }


        public SubscriptionDataMessageProcessor(
            IEnumerable<ISubscriptionDataMessageHandler> subscriptionDataMessageHandlers)
        {
            SubscriptionDataMessageHandlers = subscriptionDataMessageHandlers;
        }

        public override void ProcessMessage(Message msg, Session session)
        {

            foreach (var handler in SubscriptionDataMessageHandlers)
            {

                if (msg.MessageType.Equals(ORDER_ROUTE_FIELDS))
                {

                    int event_status = msg.GetElementAsInt32(EVENT_STATUS);

                    switch (event_status)
                    {
                        case HeartBeat:
                            handler.OnSubscriptionHeartBeat(msg, session);
                            break;
                        case InitialPaint:
                            handler.OnInitialPaint(msg, session);
                            break;
                        case InitialPaintEnd:
                            handler.OnInitialPaintEnd(msg, session);
                            break;
                        case NewOrderRoute:
                            handler.OnCreationEvent(msg, session);
                            break;
                        case OrderRouteUpdate:
                            handler.OnUpdateEvent(msg, session);
                            break;
                        case OrderRouteDeletion:
                            handler.OnDeletionEvent(msg, session);
                            break;
                        //default:
                        //    handler.OnSubscriptionMessage(msg, session);
                        //    break;
                    }
                }
                else
                {

                    handler.OnSubscriptionMessageError(msg, session);

                }

            }

        }

    }
}
