using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    internal class DeleteOrderRequest : AbstracRequest<DeleteOrderResponse>
    {
        private IEnumerable<int> EmsxSequences { get; }
        public DeleteOrderRequest(IEnumerable<int> emsxSequences)
            : base("DeleteOrder")
        {
            EmsxSequences = emsxSequences;

        }
        public DeleteOrderRequest(int emsxSequence)
            : this(new List<int>() { emsxSequence })
        {


        }
        public override IResponseHandler CreateResponseHandler(TaskCompletionSource<DeleteOrderResponse> taskCompletionSource)
        {
            return new ResponseHandler<DeleteOrderRequest, DeleteOrderResponse>(
                "DeleteOrder",
                RequestId,
                new DeleteOrderResponseParser(),
                taskCompletionSource);
        }
        protected override Request BuildRequest(Request request)
        {
            EmsxSequences
                .ToList()
                .ForEach(x => request.GetElement(EMSX_SEQUENCE)
                .AppendValue(x));
            return request;
        }
    }
}
