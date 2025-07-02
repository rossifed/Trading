using Request = Bloomberglp.Blpapi.Request;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class AssignTraderRequest : AbstractRequest<AssignTraderResponse>
    {

        public IEnumerable<int> Sequences { get; }
        public int AssigneeTraderUuid { get; }
        public AssignTraderRequest(IEnumerable<int> sequences, int assigneeTraderUuid) : base("AssignTrader")
        {
            this.Sequences = sequences;
            this.AssigneeTraderUuid = assigneeTraderUuid;
        }

        public AssignTraderRequest(int sequence, int assigneeTraderUuid) : this(new List<int>() { sequence }, assigneeTraderUuid)
        {
        }

        protected override Request BuildRequest(Request request)
        {
            Sequences.ToList().ForEach(sequence => request.Append(EMSX_SEQUENCE, sequence));
            request.Set(EMSX_ASSIGNEE_TRADER_UUID, AssigneeTraderUuid);
            return request;
        }

        public override IResponseEventHandler<AssignTraderResponse> CreateResponseHandler(IEmsxEventHandler messageEventDispatcher)
          => new AssignTraderResponseHandler(messageEventDispatcher, this);

    }
}
