using Bloomberglp.Blpapi;
using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Element = Bloomberglp.Blpapi.Element;
using Request = Bloomberglp.Blpapi.Request;
using Service = Bloomberglp.Blpapi.Service;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CancelRouteRequest : AbstractRequest<CancelRouteResponse>
    {

        public const string RequestName = "CancelRoute";

        private int Sequence { get; }

        private int RouteId { get; }
        public CancelRouteRequest(int sequence, int routeId):base(RequestName) 
        {
            this.Sequence = sequence;
            this.RouteId = routeId;

        }
 

      

        protected override Request BuildRequest(Request request)
        {
            Element routes = request.GetElement(ROUTES); //Note, the case is important.
            Element route = routes.AppendElement(); // Multiple routes can be cancelled in a single request
            route.GetElement(EMSX_SEQUENCE).SetValue(Sequence);
            route.GetElement(EMSX_ROUTE_ID).SetValue(RouteId);
            return request;
        }

        public override IResponseEventHandler<CancelRouteResponse> CreateResponseHandler(IEmsxEventHandler messageEventDispatcher)
            => new CancelRouteResponseHandler(messageEventDispatcher, this);
        public override string? ToString()
        {
            return $"Sequence:{Sequence} Route:{RouteId}";
        }
    }
}
