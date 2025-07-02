using Bloomberglp.Blpapi;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers
{
    internal class CancelOrderResponseParser : IMessageParser<CancelOrderResponse>
    {
        public CancelOrderResponse Parse(Message msg)
        {
            int status = msg.GetElementAsInt32(STATUS);
            String message = msg.GetElementAsString(MESSAGE);
            return new CancelOrderResponse(status, message);
        }
    }
}
