using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors
{
    internal interface ISessionMessageProcessor : IMessageProcessor { };
    internal class SessionMessageProcessor : AbstractMessageProcessor, ISessionMessageProcessor
    {
        private static readonly Name SESSION_STARTED = new Name("SessionStarted");
        private static readonly Name SESSION_STARTUP_FAILURE = new Name("SessionStartupFailure");
        private static readonly Name SESSION_CONNECTION_UP = new Name("SessionConnectionUp");
        private static readonly Name SESSION_CONNECTION_DOWN = new Name("SessionConnectionDown");
        private  IEnumerable<ISessionMessageHandler> SessionMessageHandlers { get; }


        public SessionMessageProcessor(
           IEnumerable<ISessionMessageHandler> sessionMessageHandlers)
        {
            SessionMessageHandlers = sessionMessageHandlers;
    
        }




        public override void ProcessMessage(Message msg, Session session)
        {
            foreach (var handler in SessionMessageHandlers)
            {
                if (msg.MessageType.Equals(SESSION_STARTED))
                {

                    handler.OnSessionStarted(msg, session);
                }
                else if (msg.MessageType.Equals(SESSION_STARTUP_FAILURE))
                {
                    handler.OnSessionStartupFailure(msg, session);
                }
                else if (msg.MessageType.Equals(SESSION_CONNECTION_UP))
                {
                    handler.OnSessionConnectionUp(msg, session);
                }
                else if (msg.MessageType.Equals(SESSION_CONNECTION_DOWN))
                {
                    handler.OnSessionConnectionDown(msg, session);
                }
            }
        }
        

    }
    
}
