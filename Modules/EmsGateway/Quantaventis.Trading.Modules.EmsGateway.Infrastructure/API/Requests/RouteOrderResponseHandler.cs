using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
using Message = Bloomberglp.Blpapi.Message;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class RouteOrderResponseHandler : AbstractResponseHandler<RouteOrderRequest, RouteOrderResponse>
    {

        public RouteOrderResponseHandler(IEmsxEventHandler messageEventDispatcher, RouteOrderRequest routeOrderRequest)
            : base(messageEventDispatcher, routeOrderRequest, "Route")//the fucking emsx api send RouteEx but get Route as message type....
        {

        }


        protected override RouteOrderResponse CreateResponse(Message msg)
        {
            int emsxSequence = msg.GetElementAsInt32(EMSX_SEQUENCE);
            int routeId = msg.GetElementAsInt32(EMSX_ROUTE_ID);
            String message = msg.GetElementAsString(MESSAGE);
            return new RouteOrderResponse(emsxSequence, routeId, message, Request);
        }
    }
}
