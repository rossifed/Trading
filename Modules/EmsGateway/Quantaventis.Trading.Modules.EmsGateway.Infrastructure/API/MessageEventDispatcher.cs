

using Bloomberglp.Blpapi;
using static Bloomberglp.Blpapi.SubscriptionPreprocessError;
using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Event = Bloomberglp.Blpapi.Event;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class MessageEventDispatcher : IEmsxEventHandler
    {
        private static readonly Name SESSION_STARTED = new Name("SessionStarted");
        private static readonly Name SESSION_STARTUP_FAILURE = new Name("SessionStartupFailure");
        private static readonly Name SERVICE_OPENED = new Name("ServiceOpened");
        private static readonly Name SERVICE_OPEN_FAILURE = new Name("ServiceOpenFailure");
        private static readonly Name SESSION_CONNECTION_UP = new Name("SessionConnectionUp");
        private static readonly Name SESSION_CONNECTION_DOWN = new Name("SessionConnectionDown");

        private static readonly Name SUBSCRIPTION_FAILURE = new Name("SubscriptionFailure");
        private static readonly Name SUBSCRIPTION_STARTED = new Name("SubscriptionStarted");
        private static readonly Name SUBSCRIPTION_TERMINATED = new Name("SubscriptionTerminated");

        private static readonly Name ORDER_ROUTE_FIELDS = new Name("OrderRouteFields");

        private static readonly Name ERROR_INFO = new Name("ErrorInfo");


        private static readonly Name CREATE_ORDER = new Name("CreateOrder");

        public event Action<Message>? SubscriptionMessageEvent;
        public event Action<CorrelationID>? InitialPaintEndEvent;
        public event Action<CorrelationID>? SubscriptionTerminatedEvent;
        public event Action<Message>? ResponseMessageEvent;
        public event Action<EmsxApiException>? ErrorEvent;

        public MessageEventDispatcher()
        {

        }
        private void DispatchMessage<T>(Action<T>? actionEvent, T message)
        => actionEvent?.Invoke(message);

        private void DispatchMessage(Action? actionEvent)
         => actionEvent?.Invoke();

        public void OnSessionStarted()
        {

        }

        public void OnSessionStartupFailure()
        {

        }

        public void OnSessionConnectionUp()
        {

        }

        public void OnSessionConnectionDown()
        {

        }

        public void OnServiceOpen()
        {

        }

        public void OnSubscriptionStarted(CorrelationID correlationID)
        {

        }

        public void OnSubscriptionFailure(CorrelationID correlationID)
        {

        }

        public void OnSubscriptionTerminated(CorrelationID correlationID)
        {
            DispatchMessage<CorrelationID>(SubscriptionTerminatedEvent, correlationID);
        }

        public void OnInitialPaintEnd(CorrelationID correlationID)
        {
            DispatchMessage<CorrelationID>(InitialPaintEndEvent, correlationID);
        }

        public void OnHeartBeat(CorrelationID correlationID)
        {

        }

        public void OnSubscriptionMessage(Message message)
        {
            DispatchMessage<Message>(SubscriptionMessageEvent, message);
        }

        public void OnResponseMessage(Message message)
        {
            DispatchMessage<Message>(ResponseMessageEvent, message);
        }

        public void OnMiscEvent(Event.EventType eventType, Message message)
        {

        }

        public void OnError(int errorCode, string errorMessage)
        {
            DispatchMessage<EmsxApiException>(ErrorEvent, new EmsxApiException(errorCode, errorMessage));
        }

        public void OnError(string errorMessage)
        {
            DispatchMessage<EmsxApiException>(ErrorEvent, new EmsxApiException(errorMessage));
        }
    }
}
