using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    internal class CancelOrderRequest : AbstracRequest<CancelOrderResponse>
    {

        private IEnumerable<int> Sequences { get; }


        public CancelOrderRequest(IEnumerable<int> sequences) : base("CancelOrderEx")
        {
            Sequences = sequences;

        }

        public CancelOrderRequest(int sequence) : this(new List<int>() { sequence })
        {

        }



        protected override Request BuildRequest(Request request)
        {
            Sequences.ToList().ForEach(x => request.GetElement(EMSX_SEQUENCE).AppendValue(x));
            return request;
        }

        public override IResponseHandler CreateResponseHandler(TaskCompletionSource<CancelOrderResponse> taskCompletionSource)
        {
            return new ResponseHandler<CancelOrderRequest, CancelOrderResponse>(
                "CancelOrderEx",
                RequestId,
                new CancelOrderResponseParser(),
                taskCompletionSource);
        }
    }
}
