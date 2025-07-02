using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
using Message = Bloomberglp.Blpapi.Message;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CreateOrderAndRouteResponseHandler : AbstractResponseHandler<CreateOrderAndRouteRequest, CreateOrderAndRouteResponse>
    {

        public CreateOrderAndRouteResponseHandler(
            IEmsxEventHandler messageEventDispatcher,
            CreateOrderAndRouteRequest request)
            : base(messageEventDispatcher, request)
        {

        }


        protected override CreateOrderAndRouteResponse CreateResponse(Message msg)
        {
            int emsx_sequence = msg.GetElementAsInt32(EMSX_SEQUENCE);
            int routeid = msg.GetElementAsInt32(EMSX_ROUTE_ID);
            String message = msg.GetElementAsString(MESSAGE);
            return new CreateOrderAndRouteResponse(emsx_sequence, routeid, message, Request);
        }
    }
}
