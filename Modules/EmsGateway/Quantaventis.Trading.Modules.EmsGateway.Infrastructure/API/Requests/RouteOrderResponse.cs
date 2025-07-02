namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class RouteOrderResponse
    {

        public int EmsxSequence { get; }

        public int RouteId { get; }

        public string Message { get; }

        public RouteOrderRequest Request { get; }
        public RouteOrderResponse(int emsxSequence, int routeId, string message, RouteOrderRequest request)
        {
            EmsxSequence = emsxSequence;
            RouteId = routeId;
            Message = message;
            Request = request;
            
        }

        public override string? ToString()
            => $"{Request} {EmsxSequence} {RouteId} {Message}";
    }
}
