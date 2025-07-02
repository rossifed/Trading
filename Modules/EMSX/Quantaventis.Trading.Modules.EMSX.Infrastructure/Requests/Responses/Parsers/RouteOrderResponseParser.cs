using Bloomberglp.Blpapi;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers
{
    internal class RouteOrderResponseParser : IMessageParser<RouteOrderResponse>
    {
        public RouteOrderResponse Parse(Message msg)
        {
            int emsxSequence = msg.GetElementAsInt32(EMSX_SEQUENCE);
            int routeId = msg.GetElementAsInt32(EMSX_ROUTE_ID);
            String message = msg.GetElementAsString(MESSAGE);
            return new RouteOrderResponse(emsxSequence, routeId, message);
        }
    }
}
