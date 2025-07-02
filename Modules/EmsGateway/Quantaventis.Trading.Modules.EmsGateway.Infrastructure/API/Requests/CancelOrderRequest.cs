using Request = Bloomberglp.Blpapi.Request;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CancelOrderRequest : AbstractRequest<CancelOrderResponse>
    {

        private IEnumerable<int> Sequences { get; }


        public CancelOrderRequest(IEnumerable<int> sequences) : base("CancelOrderEx")
        {
            this.Sequences = sequences;

        }

        public CancelOrderRequest(int sequence) : this(new List<int>() { sequence })
        {

        }

        public override IResponseEventHandler<CancelOrderResponse> CreateResponseHandler(IEmsxEventHandler messageEventDispatcher)
        => new CancelOrderResponseHandler(messageEventDispatcher, this);

        protected override Request BuildRequest(Request request)
        {
            Sequences.ToList().ForEach(x => request.GetElement(EMSX_SEQUENCE).AppendValue(x));
            return request;
        }


    }
}
