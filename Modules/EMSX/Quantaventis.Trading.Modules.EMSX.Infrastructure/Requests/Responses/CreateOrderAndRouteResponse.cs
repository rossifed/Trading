namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses
{
    internal class CreateOrderAndRouteResponse
    {
        public int EmsxSequence { get; }

        public string Message { get; }
        public int RouteId { get; }
        public CreateOrderAndRouteResponse(int emsxSequence, int routeId, string message)
        {
            EmsxSequence = emsxSequence;
            Message = message;
            RouteId = routeId;
        }

        public override string? ToString()
               => $"EmsxSequence:{EmsxSequence} Route:{RouteId}. {Message}";
    }
}
