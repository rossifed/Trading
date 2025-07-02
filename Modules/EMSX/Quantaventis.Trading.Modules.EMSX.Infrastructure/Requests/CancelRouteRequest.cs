using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Element = Bloomberglp.Blpapi.Element;
using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    internal class CancelRouteRequest : AbstracRequest<CancelRouteResponse>
    {     

        private int Sequence { get; }

        private int RouteId { get; }
        public CancelRouteRequest(int sequence, int routeId) : base("CancelRoute")
        {
            Sequence = sequence;
            RouteId = routeId;

        }


        protected override Request BuildRequest(Request request)
        {
            Element routes = request.GetElement(ROUTES); //Note, the case is important.
            Element route = routes.AppendElement(); // Multiple routes can be cancelled in a single request
            route.GetElement(EMSX_SEQUENCE).SetValue(Sequence);
            route.GetElement(EMSX_ROUTE_ID).SetValue(RouteId);
            return request;
        }

        public override IResponseHandler CreateResponseHandler(TaskCompletionSource<CancelRouteResponse> taskCompletionSource)
        {
            return new ResponseHandler<CancelRouteRequest, CancelRouteResponse>(
                "CancelRoute",
                RequestId,
                new CancelRouteResponseParser(),
                taskCompletionSource);
        }

        public override string? ToString()
        {
            return $"Sequence:{Sequence} Route:{RouteId}";
        }
    }
}
