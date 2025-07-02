using System.Linq;
using static Bloomberglp.Blpapi.Schema;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CreateBasketResponse
    {

        public string Message { get; }

        public CreateBasketRequest Request { get; }
        public CreateBasketResponse(string message, CreateBasketRequest request)
        {
            Message = message;
            Request = request;
        }
        public override string? ToString()
                 => $"{Message} {Request}";
    }
}
