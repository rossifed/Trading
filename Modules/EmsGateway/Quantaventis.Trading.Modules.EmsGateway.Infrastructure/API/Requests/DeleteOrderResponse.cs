using static Bloomberglp.Blpapi.Schema;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class DeleteOrderResponse
    {

        public int EmsxSequence { get; }

        public string Message { get; }
        public DeleteOrderRequest Request { get; }
        public DeleteOrderResponse(int emsxSequence, string message, DeleteOrderRequest request)
        {
            EmsxSequence = emsxSequence;
            Message = message;
            Request = request;
        }

        public override string? ToString()
             => $"{EmsxSequence} {Message} {Request}";
    }
}
