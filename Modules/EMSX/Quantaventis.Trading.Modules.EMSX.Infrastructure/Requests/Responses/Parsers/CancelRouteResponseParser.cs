using Bloomberglp.Blpapi;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers
{
    internal class CancelRouteResponseParser : IMessageParser<CancelRouteResponse>
    {
        public CancelRouteResponse Parse(Message msg)
        {
            int status = msg.GetElementAsInt32(STATUS);
            String message = msg.GetElementAsString(MESSAGE);
            return new CancelRouteResponse(status, message);
        }
    }
}
