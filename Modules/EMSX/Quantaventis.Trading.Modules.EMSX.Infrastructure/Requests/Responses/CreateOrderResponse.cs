namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses
{
    internal class CreateOrderResponse
    {
        public int EmsxSequence { get; }

        public string Message { get; }
        public CreateOrderResponse(int emsxSequence, string message)
        {
            EmsxSequence = emsxSequence;
            Message = message;

        }

        public override string? ToString()
               => $"EmsxSequence:{EmsxSequence} {Message}";

    }
}
