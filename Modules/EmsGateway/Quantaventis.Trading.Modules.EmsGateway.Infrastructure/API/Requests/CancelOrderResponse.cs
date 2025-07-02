namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CancelOrderResponse
    {

        public int Status { get; }

        public string Message { get; }

        public CancelOrderRequest Request { get; }
        public CancelOrderResponse(int status, string message, CancelOrderRequest cancelOrderRequest)
        {
            Status = status;
            Message = message;
            Request = cancelOrderRequest;
        }

        public override string? ToString()
           => $"{Status} {Message} : {Request}";

    }
}
