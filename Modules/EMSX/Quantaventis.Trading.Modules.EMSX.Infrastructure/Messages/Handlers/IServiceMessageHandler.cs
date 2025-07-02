using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers
{
    internal interface IServiceMessageHandler
    {
        void OnServiceOpened(Message msg, Session session);
        void OnServiceOpenFailure(Message msg, Session session);
    }
}

