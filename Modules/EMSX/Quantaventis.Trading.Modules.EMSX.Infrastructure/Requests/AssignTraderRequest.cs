using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Request = Bloomberglp.Blpapi.Request;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    internal class AssignTraderRequest : AbstracRequest<AssignTraderResponse>
    {

        internal IEnumerable<int> Sequences { get; }
        internal int AssigneeTraderUuid { get; }
        internal AssignTraderRequest(IEnumerable<int> sequences, int assigneeTraderUuid) : base("AssignTrader")
        {
            Sequences = sequences;
            AssigneeTraderUuid = assigneeTraderUuid;
        }

        internal AssignTraderRequest(int sequence, int assigneeTraderUuid) : this(new List<int>() { sequence }, assigneeTraderUuid)
        {
        }

        protected override Request BuildRequest(Request request)
        {
            Sequences.ToList().ForEach(sequence => request.Append(EMSX_SEQUENCE, sequence));
            request.Set(EMSX_ASSIGNEE_TRADER_UUID, AssigneeTraderUuid);
            return request;
        }

        public override IResponseHandler CreateResponseHandler(TaskCompletionSource<AssignTraderResponse> taskCompletionSource)
        {
            return new ResponseHandler<AssignTraderRequest, AssignTraderResponse>(
                "AssignTrader",
                RequestId,
                new AssignTraderResponseParser(),
                taskCompletionSource);
        }
    }
}
