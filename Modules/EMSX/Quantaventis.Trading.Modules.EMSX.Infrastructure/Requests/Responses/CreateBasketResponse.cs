namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses
{
    internal class CreateBasketResponse
    {
        public string Message { get; }

        public CreateBasketResponse(string message)
        {
            Message = message;

        }
        public override string? ToString()
                 => $"{Message}";
    }
}
