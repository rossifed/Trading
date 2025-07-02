using Bloomberglp.Blpapi;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers
{
    internal class CreateOrderAndRouteResponseParser : IMessageParser<CreateOrderAndRouteResponse>
    {
        public CreateOrderAndRouteResponse Parse(Message msg)
        {
            int emsx_sequence = msg.GetElementAsInt32(EMSX_SEQUENCE);
            int routeid = msg.GetElementAsInt32(EMSX_ROUTE_ID);
            String message = msg.GetElementAsString(MESSAGE);
            return new CreateOrderAndRouteResponse(emsx_sequence, routeid, message);
        }
    }
}
