
using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class AssignTraderResponse
    {
        public AssignTraderStatus Status { get; }

        public IEnumerable<int> Sequences { get; }

        public AssignTraderRequest Request { get; }

        public AssignTraderResponse(AssignTraderStatus status, IEnumerable<int> sequences, AssignTraderRequest request)
        {
            Status = status;
            Sequences = sequences;
            Request = request;
        }

        public override string? ToString()
         => $"{base.ToString()} {Status} : {Request}";
    }

    public enum AssignTraderStatus
    {
        FullSuccess, PartialSuccess, Failure, Unknown
    }
}
