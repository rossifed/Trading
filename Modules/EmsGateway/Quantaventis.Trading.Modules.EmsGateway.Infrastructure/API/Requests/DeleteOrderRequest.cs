using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
using Request = Bloomberglp.Blpapi.Request;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class DeleteOrderRequest : AbstractRequest<DeleteOrderResponse>
    {
        private IEnumerable<int> EmsxSequences { get; }
        public DeleteOrderRequest(IEnumerable<int> emsxSequences) 
            : base("DeleteOrder")
        {
            this.EmsxSequences = emsxSequences;

        }
        public DeleteOrderRequest(int emsxSequence) 
            : this(new List<int>() { emsxSequence })
        {


        }

        protected override Request BuildRequest(Request request)
        {
            EmsxSequences
                .ToList()
                .ForEach(x => request.GetElement(EMSX_SEQUENCE)
                .AppendValue(x));
            return request;
        }

        public override IResponseEventHandler<DeleteOrderResponse> CreateResponseHandler(IEmsxEventHandler messageEventDispatcher)
            => new DeleteOrderResponseHandler(messageEventDispatcher, this);
    }
}
