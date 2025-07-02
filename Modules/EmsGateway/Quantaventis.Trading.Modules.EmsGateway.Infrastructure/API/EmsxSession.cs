
using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Event = Bloomberglp.Blpapi.Event;
using EventHandler = Bloomberglp.Blpapi.EventHandler;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using Request = Bloomberglp.Blpapi.Request;
using Service = Bloomberglp.Blpapi.Service;
using Session = Bloomberglp.Blpapi.Session;
using SessionOptions = Bloomberglp.Blpapi.SessionOptions;
using Subscription = Bloomberglp.Blpapi.Subscription;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Subscriptions;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class EmsxSession
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

        private string ServiceName { get; }
        private string Host => SessionOptions.ServerHost;
        private int Port => SessionOptions.ServerPort;

        private Session Session { get; }
        private IEmsxEventHandler EventHandler { get; }
        private SessionOptions SessionOptions { get; }

        public bool IsOpen { get; private set; } = false;

        public bool Aborted { get; private set; } = false;
        public EmsxSession(EmsxSessionOptions emsxSessionOptions, IEmsxEventHandler emsxEventHandler)
        {
            ServiceName = emsxSessionOptions.Service;
            EventHandler = emsxEventHandler;
            SessionOptions = CreateSessionOptions(emsxSessionOptions.Host, emsxSessionOptions.Port);
            Session = new Session(SessionOptions, new EventHandler(ProcessEvent));
        }
        public EmsxSession(EmsxSessionOptions emsxSessionOptions)
        : this(emsxSessionOptions, new MessageEventDispatcher()) { }

        public void StartAsync()
        {

            Session.StartAsync();

        }



        private static SessionOptions CreateSessionOptions(string host, int port)
        {
            SessionOptions sessionOptions = new SessionOptions();
            sessionOptions.ServerHost = host;
            sessionOptions.ServerPort = port;
            return sessionOptions;

        }

        public Service GetService()
            => Session.GetService(ServiceName);

        public void SendRequest(Request request, CorrelationID requestId)
        {
            try
            {
                Session.SendRequest(request, requestId);
            }
            catch (Exception ex)
            {
                EventHandler?.OnError("Failed to send the request: " + ex.Message);
            }
        }
        public ISubscriptionEventHandler<EventType> Subscribe<EventType>(ISubscription<EventType> sub)
        => Subscribe(sub, (correlationID,eventType) => { });
        public ISubscriptionEventHandler<EventType> Subscribe<EventType>(ISubscription<EventType> sub, Action<CorrelationID, EventType> onEventAction)
        {
            CorrelationID correlationId = new CorrelationID();

            ISubscriptionEventHandler<EventType> subscriptionEventHandler = sub.CreateSubscriptionEventHandler(correlationId, EventHandler, onEventAction);
            Service service = GetService();

            Session.Subscribe(new List<Subscription>() { new Subscription(sub.CreateTopic(service), correlationId) });
            return subscriptionEventHandler;
        }
        public async Task<IEnumerable<EventType>> SubscribeAndGetResponseAsync<EventType>(ISubscription<EventType> sub)
        {
            ISubscriptionEventHandler<EventType> handler = Subscribe(sub);
            IEnumerable<EventType> response = await handler.GetResponseAsync();
            UnSubscribe(handler.SubscriptionId);
            return response;
        }

        public IEnumerable<EventType> SubscribeAndGetResponse<EventType>(ISubscription<EventType> sub)
        {
            ISubscriptionEventHandler<EventType> handler = Subscribe(sub);
            IEnumerable<EventType> response =  handler.GetResponse();
            UnSubscribe(handler.SubscriptionId);
            return response;
        }


        public void UnSubscribe<EventType>(CorrelationID correlationId)
         => Session.Cancel(correlationId);


        public IResponseEventHandler<ResponseType> SendRequest<ResponseType>(IRequest<ResponseType> request)
        {
            if (IsOpen)
            {
                //CorrelationID requestId = new CorrelationID();
                IResponseEventHandler<ResponseType> responseEventHandler = request.CreateResponseHandler(EventHandler);
                Service service = GetService();

                Session.SendRequest(request.CreateRequest(service), request.CorrelationID);
                return responseEventHandler;
            }
            else {
                throw new InvalidOperationException($"Request {request} can't be send, the EMSX Session is Closed...");
            }
        }

        public async Task<ResponseType> SendRequestAndGetResponseAsync<ResponseType>(IRequest<ResponseType> request)
         => await SendRequest(request).GetResponseAsync();

        public ResponseType SendRequestAndGetResponse<ResponseType>(IRequest<ResponseType> request)
         => SendRequest(request).GetResponse();


        public void ProcessEvent(Event evt, Session session)
        {
            
                switch (evt.Type)
                {
                    case Event.EventType.ADMIN:
                        ProcessSessionEvent(evt, session);
                        break;
                    case Event.EventType.SESSION_STATUS:
                        ProcessSessionEvent(evt, session);
                        break;
                    case Event.EventType.SERVICE_STATUS:
                        processServiceEvent(evt, session);
                        break;
                    case Event.EventType.RESPONSE:
                        ProcessResponseEvent(evt, session);
                        break;
                    case Event.EventType.SUBSCRIPTION_STATUS:
                        ProcessSubscriptionStatusEvent(evt, session);
                        break;
                    case Event.EventType.SUBSCRIPTION_DATA:
                        ProcessSubscriptionDataEvent(evt, session);
                        break;
                    default:
                        ProcessMiscEvents(evt, session);
                        break;
                }        
        }

        private void ProcessSessionEvent(Event evt, Session session)
        {

            foreach (Message msg in evt)
            {
                if (msg.MessageType.Equals(SESSION_STARTED))
                {

                    session.OpenServiceAsync(ServiceName);

                }
                else if (msg.MessageType.Equals(SESSION_STARTUP_FAILURE))
                {
                    Aborted = true;
                    EventHandler?.OnSessionStartupFailure();
                }
                else if (msg.MessageType.Equals(SESSION_CONNECTION_UP))
                {
                    EventHandler?.OnSessionConnectionUp();
                }
                else if (msg.MessageType.Equals(SESSION_CONNECTION_DOWN))
                {
                    EventHandler?.OnSessionConnectionDown();
                }
            }
        }

        private void processServiceEvent(Event evt, Session session)
        {
            foreach (Message msg in evt)
            {
                if (msg.MessageType.Equals(SERVICE_OPENED))
                {
                    try
                    {
                        IsOpen = true;
                    }
                    catch (Exception ex)
                    {
                        Aborted = true;
                        EventHandler?.OnError("Failed to send the request: " + ex.Message);
                    }

                }
                else if (msg.MessageType.Equals(SERVICE_OPEN_FAILURE))
                {
                    Aborted = true;
                    EventHandler?.OnError("Error: Service failed to open");
                }
            }
        }
        private void ProcessSubscriptionStatusEvent(Event evt, Session session)
        {
            foreach (Message msg in evt)
            {

                if (msg.MessageType.Equals(SUBSCRIPTION_STARTED))
                {
                    EventHandler?.OnSubscriptionStarted(msg.CorrelationID);
                }
                else if (msg.MessageType.Equals(SUBSCRIPTION_FAILURE))
                {
                    EventHandler?.OnSubscriptionFailure(msg.CorrelationID);
                }
                else if (msg.MessageType.Equals(SUBSCRIPTION_TERMINATED))
                {
                    EventHandler?.OnSubscriptionTerminated(msg.CorrelationID);
                }
            }
        }

        private void ProcessSubscriptionDataEvent(Event evt, Session session)
        {

            void ProcessOrderRouteFieldsMessage(Message msg)
            {
                int event_status = msg.GetElementAsInt32("EVENT_STATUS");

                switch (event_status)
                {
                    case EventStatus.HeartBeat:
                        EventHandler?.OnHeartBeat(msg.CorrelationID);
                        break;
                    case EventStatus.InitialPaintEnd:
                        EventHandler?.OnInitialPaintEnd(msg.CorrelationID);
                        break;
                    default:
                        EventHandler?.OnSubscriptionMessage(msg);
                        break;
                }//
            }

            foreach (Message msg in evt)
            {
                if (msg.MessageType.Equals(ORDER_ROUTE_FIELDS))
                {

                    ProcessOrderRouteFieldsMessage(msg);
                }
                else
                {
                    EventHandler?.OnError("Error: Unexpected message");
                }

            }


        }
        private void ProcessResponseEvent(Event evt, Session session)
        {
            void ProcessResponse(Message msg)
            {

                if (msg.MessageType.Equals(ERROR_INFO))
                {
                    int errorCode = msg.GetElementAsInt32("ERROR_CODE");
                    String errorMessage = msg.GetElementAsString("ERROR_MESSAGE");
                    EventHandler?.OnError(errorCode, errorMessage);
                }
                else
                {
                    EventHandler?.OnResponseMessage(msg);
                }
            }

            foreach (Message msg in evt)
            {
                if (evt.Type == Event.EventType.RESPONSE)
                {
                    ProcessResponse(msg);
                }
            }
        }
        private void ProcessMiscEvents(Event evt, Session session)
        {
            foreach (Message msg in evt)
            {
                EventHandler?.OnMiscEvent(evt.Type, msg);
            }
        }
        public void Subscribe(string topic, CorrelationID subscriptionId)
        {
            Subscription subscription = new Subscription(topic, subscriptionId);
            Session.Subscribe(new List<Subscription>() { subscription });
        }
        public void UnSubscribe(CorrelationID subscriptionId)
        {
            Session.Cancel(subscriptionId);
        }
        public void Stop()
        {
            Session.Stop();
            IsOpen = false;
        }

 
     

    }
}
