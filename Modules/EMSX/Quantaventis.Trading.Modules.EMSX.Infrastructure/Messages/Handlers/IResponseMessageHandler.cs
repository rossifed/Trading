using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers
{
    internal interface IResponseMessageHandler
    {
        void OnResponseError(Message msg, Session session);
        void OnResponseMessage(Message msg, Session session);

        void OnPartialResponseMessage(Message msg, Session session);
    }
}
