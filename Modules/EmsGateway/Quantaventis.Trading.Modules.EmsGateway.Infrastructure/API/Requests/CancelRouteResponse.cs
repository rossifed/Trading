namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CancelRouteResponse
    {

        public int Status { get; }

        public string Message { get; }

        public CancelRouteRequest Request { get; }
        public CancelRouteResponse(int status, string message, CancelRouteRequest cancelRouteRequest)
        {
            Status = status;
            Message = message;
            Request = cancelRouteRequest;

        }

        public override string? ToString()
            => $"{Status} {Message} {Request}";

    }
}
