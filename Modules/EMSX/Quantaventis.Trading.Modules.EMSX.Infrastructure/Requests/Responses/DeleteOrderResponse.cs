namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses
{
    internal class DeleteOrderResponse
    {
        public int Status { get; }
        public string Message { get; }
        public DeleteOrderResponse(int status, string message)
        {
            Status = status;
            Message = message;
        }

        public override string? ToString()
             => $"{Message} Status:{Status}";
    }
}
