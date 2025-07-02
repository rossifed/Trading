using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers
{
    internal interface ISessionMessageHandler
    {
        void OnSessionStarted(Message msg, Session session);
        void OnSessionStartupFailure(Message msg, Session session);
        void OnSessionConnectionUp(Message msg, Session session);

        void OnSessionConnectionDown(Message msg, Session session);
    }
}

