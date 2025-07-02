namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses
{
    internal class CancelOrderResponse
    {
        internal int Status { get; }

        internal string Message { get; }
        public CancelOrderResponse(int status, string message)
        {
            Status = status;
            Message = message;
        }
        public override string? ToString()
         => $"{Message} Status:{Status}";

    }
}
