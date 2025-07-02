using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    internal class CreateBasketRequest : AbstracRequest<CreateBasketResponse>
    {
        public const string RequestName = "CreateBasket";
        public string BasketName { get; }

        private IEnumerable<int> Sequences { get; }
        public CreateBasketRequest(string basketName, IEnumerable<int> sequences) : base("CreateBasket")
        {
            BasketName = basketName;
            Sequences = sequences;

        }




        protected override Request BuildRequest(Request request)
        {
            request.Set(EMSX_BASKET_NAME, BasketName);
            Sequences.ToList().ForEach(x => request.Append(EMSX_SEQUENCE, x));
            return request;
        }

        public override string? ToString()
        {
            return $"CreateBasket: {BasketName}";
        }

        public override IResponseHandler CreateResponseHandler(TaskCompletionSource<CreateBasketResponse> taskCompletionSource)
        {
            return new ResponseHandler<CreateBasketRequest, CreateBasketResponse>(
                "CreateBasket",
                RequestId,
                new CreateBasketResponseParser(),
                taskCompletionSource);
        }
    }
}
