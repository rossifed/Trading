using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Event = Bloomberglp.Blpapi.Event;
using Message = Bloomberglp.Blpapi.Message;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public interface IEmsxEventHandler 
    {
        public event Action<Message>? SubscriptionMessageEvent;
        public event Action<CorrelationID>? InitialPaintEndEvent;
        public event Action<CorrelationID>? SubscriptionTerminatedEvent;
        public event Action<EmsxApiException>? ErrorEvent;
        public event Action<Message>? ResponseMessageEvent;
        void OnSessionStarted();

        void OnSessionStartupFailure();

        void OnSessionConnectionUp();

        void OnSessionConnectionDown();

        void OnServiceOpen();

        void OnSubscriptionStarted(CorrelationID correlationID);

        void OnSubscriptionFailure(CorrelationID correlationID);

        void OnSubscriptionTerminated(CorrelationID correlationID);

        void OnInitialPaintEnd(CorrelationID correlationID);

        void OnHeartBeat(CorrelationID correlationID);

        void OnSubscriptionMessage(Message message);

        void OnResponseMessage(Message message);

        void OnMiscEvent(Event.EventType eventType, Message message);

        void OnError(int errorCode, string errorMessage);
        void OnError(string errorMessage);
    }
}
