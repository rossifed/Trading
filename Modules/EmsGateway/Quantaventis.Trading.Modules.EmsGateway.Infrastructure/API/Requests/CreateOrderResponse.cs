using static Bloomberglp.Blpapi.Schema;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CreateOrderResponse 
    {

        public int EmsxSequence { get; }

        public string Message { get; }

        public CreateOrderRequest Request { get; }
        public CreateOrderResponse(int emsxSequence, string message, CreateOrderRequest request)
        {
            EmsxSequence = emsxSequence;
            Message = message;
            Request = request;
        }

        public override string? ToString()
               => $"{Message}  {Request}";

    }
}
