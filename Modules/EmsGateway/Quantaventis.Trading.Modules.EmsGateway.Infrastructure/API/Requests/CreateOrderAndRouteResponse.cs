using static Bloomberglp.Blpapi.Schema;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CreateOrderAndRouteResponse 
    {

        public int EmsxSequence { get; }

        public string Message { get; }
        public int RouteId { get; }
        public CreateOrderAndRouteRequest Request { get; }
        public CreateOrderAndRouteResponse(int emsxSequence,int routeId, string message, CreateOrderAndRouteRequest request)
        {
            EmsxSequence = emsxSequence;
            Message = message;
            Request = request;
            RouteId = routeId;
        }

        public override string? ToString()
               => $"{EmsxSequence} {RouteId} {Message}  {Request}";

    }
}
