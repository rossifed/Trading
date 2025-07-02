using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers
{
    internal interface ISubscriptionDataMessageHandler
    {
        void OnInitialPaintEnd(Message msg, Session session);
        void OnInitialPaint(Message msg, Session session);
        void OnSubscriptionHeartBeat(Message msg, Session session);
        void OnSubscriptionMessageError(Message msg, Session session);

        void OnUpdateEvent(Message msg, Session session);

        void OnDeletionEvent(Message msg, Session session);

        void OnCreationEvent(Message msg, Session session);
    }
}
