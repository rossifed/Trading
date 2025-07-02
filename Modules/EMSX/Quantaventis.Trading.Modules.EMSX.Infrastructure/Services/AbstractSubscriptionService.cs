using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Options;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Parsers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Services
{
    internal interface ISubscriptionService<TSubscriptionMessage> : ISubscriptionDataMessageHandler, ISubscriptionStatusMessageHandler where TSubscriptionMessage : ISubscriptionMessage
    {
        void StartSubscription(Session session, ISubscriptionMessageHandler<TSubscriptionMessage> handler);
        void CancelSubscription(Session session);
    }

    internal abstract class AbstractSubscriptionService<TSubscriptionMessage> : ISubscriptionService<TSubscriptionMessage> where TSubscriptionMessage : ISubscriptionMessage
    {
        // internal ISessionManager SessionManager { get; }
        private ISubscription? Subscription { get; set; }
        private readonly object lockObject = new object();
        private ILogger<AbstractSubscriptionService<TSubscriptionMessage>> Logger { get; }

        private ISubscriptionMessageHandler<TSubscriptionMessage>? MessageHandler { get; set; }
        private ISubscriptionMessageParser<TSubscriptionMessage> MessageParser { get; }
        private InitialPaint InitialPaint { get; }
     
        private string ServiceName { get; }

        private string? TeamName { get; }
        public AbstractSubscriptionService(
             EmsxApiOptions apiOptions,
             ISubscriptionMessageParser<TSubscriptionMessage> messageParser,
            ILogger<AbstractSubscriptionService<TSubscriptionMessage>> logger)
        {
            ServiceName = apiOptions.ServiceName;
            InitialPaint = new InitialPaint();
            Subscription = new RouteSubscription();
            MessageParser = messageParser;
            TeamName = apiOptions.TeamName;
            Logger = logger;
        }

        protected abstract ISubscription CreateSubscription();
        public void StartSubscription(Session session, ISubscriptionMessageHandler<TSubscriptionMessage> handler)
        {
            lock (lockObject)
            {
                this.MessageHandler = handler;
                // Cancel existing subscription if it exists
              //  CancelSubscription(session);

                // Reset InitialPaint
                InitialPaint.Reset();

                // Create a new subscription and start it
                 Subscription = CreateSubscription();
                if(!string.IsNullOrEmpty(TeamName))
                Subscription.Start(session, ServiceName, TeamName);
                else
                 Subscription.Start(session, ServiceName);
            }
                 
        }


        //protected abstract void DispatchInitialPaintEnd(IEnumerable<TMessage> message);
        public void OnInitialPaintEnd(Message message, Session session)
        {
            if (message.CorrelationID == Subscription?.SubscriptionId)
            {

               // InitialPaint.End();
                DispatchInitialPaintAsync(InitialPaint
                     .GetMessages());
                InitialPaint.Reset();
            }

        }
        private void DispatchInitialPaintAsync(IEnumerable<Message> messages)
        {

            Task.Run(() =>
            {
                try
                {
                    IEnumerable<TSubscriptionMessage> parsedMessages = messages.Select(message => MessageParser.Parse(message));

                    MessageHandler?.OnInitialPaintEndAsync(parsedMessages);
                }
                catch (Exception e)
                {

                    Logger.LogError($"Error dispatching Initial Paint Messages for subscription {Subscription}", e);

                }
            });
        }


        private void DispatchMessageAsync(Message message, Func<TSubscriptionMessage, Task> handleMessage)
        {
            TSubscriptionMessage parsedMessage = MessageParser.Parse(message);
            Task.Run(() =>
           {
               try
               {
                   TSubscriptionMessage parsedMessage = MessageParser.Parse(message);
                   handleMessage(parsedMessage);
               }
               catch (Exception e)
               {

                   Logger.LogError($"Error dispatching subscrption {Subscription} message", e);

               }
           });
        }


        public void OnSubscriptionMessage(Message message, Session session)
        {
            if (message.CorrelationID == Subscription?.SubscriptionId)
            {
                if (InitialPaint.IsEnded)
                {
                    if(MessageHandler != null)
                    DispatchMessageAsync(message, msg=>MessageHandler.OnSubscriptionMessageAsync(msg));
                }

                else
                {
                    InitialPaint.AddMessage(message);
                }
            }
        }


        public void CancelSubscription(Session session)
        {

            lock (lockObject)
            {
                if (Subscription != null)
                {
                    Logger.LogInformation($"Stopping Subscription {Subscription}..");
                    Subscription.Cancel(session);
                    Subscription = null;
                    MessageHandler = null;
                }
            }
        }

        public virtual void OnSubscriptionHeartBeat(Message msg, Session session)
        {
            if (msg.CorrelationID == Subscription?.SubscriptionId)
            {
                Logger.LogTrace($"Subcription {Subscription}  Hear Beat...");

            }


        }

        public virtual void OnSubscriptionMessageError(Message msg, Session session)
        {
            if (msg.CorrelationID == Subscription?.SubscriptionId)
            {
                Logger.LogError($"Subscription {Subscription} Error Message. {msg}");

            }

        }

        public virtual void OnSubscriptionStarted(Message msg, Session session)
        {
            if (msg.CorrelationID == Subscription?.SubscriptionId)
            {
                Logger.LogInformation($"Subscription {Subscription} Started...");

            }

        }

        public virtual void OnSubscriptionTerminated(Message msg, Session session)
        {
            if (msg.CorrelationID == Subscription?.SubscriptionId)
            {
                Logger.LogInformation($"Subscription {Subscription} Terminated...");

            }

        }

        public virtual void OnSubscriptionFailure(Message msg, Session session)
        {
            if (msg.CorrelationID == Subscription?.SubscriptionId)
            {
                Logger.LogError($"Error: Subscription {Subscription} Failed...");

            }

        }

        public void OnUpdateEvent(Message message, Session session)
        {
            if (MessageHandler != null)
                DispatchMessageAsync(message, msg => MessageHandler.OnUpdateEventAsync(msg));
        }

        public void OnDeletionEvent(Message message, Session session)
        {
            if (MessageHandler != null)
                DispatchMessageAsync(message, msg => MessageHandler.OnDeletionEventAsync(msg));
        }

        public void OnCreationEvent(Message message, Session session)
        {
            if (MessageHandler != null)
                DispatchMessageAsync(message, msg => MessageHandler.OnCreationEventAsync(msg));
        }

        public void OnInitialPaint(Message msg, Session session)
        {
            InitialPaint.AddMessage(msg);
        }
    }
}
