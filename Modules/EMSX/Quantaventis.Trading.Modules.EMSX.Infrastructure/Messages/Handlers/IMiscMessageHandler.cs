using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers
{
    internal interface IMiscMessageHandler
    {
        void OnMiscMessage(Message msg, Session session);
    }
}
