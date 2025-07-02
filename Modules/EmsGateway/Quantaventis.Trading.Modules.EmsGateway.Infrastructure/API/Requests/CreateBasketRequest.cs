using Request = Bloomberglp.Blpapi.Request;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CreateBasketRequest : AbstractRequest<CreateBasketResponse>
    {
        public const string RequestName = "CreateBasket";
        public string BasketName { get; }

        private IEnumerable<int> Sequences { get; }
        public CreateBasketRequest(string basketName, IEnumerable<int> sequences) : base("CreateBasket")
        {
            this.BasketName = basketName;
            this.Sequences = sequences;

        }

        protected override Request BuildRequest(Request request)
        {
            request.Set(EMSX_BASKET_NAME, BasketName);
            Sequences.ToList().ForEach(x => request.Append(EMSX_SEQUENCE, x));
            return request;
        }

        public override IResponseEventHandler<CreateBasketResponse> CreateResponseHandler(IEmsxEventHandler messageEventDispatcher)
           => new CreateBasketResponseHandler(messageEventDispatcher, this);
    }
}
