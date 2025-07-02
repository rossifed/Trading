namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses
{
    internal class AssignTraderResponse
    {
        internal IEnumerable<int> SuccesfullSequences { get; }
        internal IEnumerable<int> FailedSequences { get; }
        internal AssignTraderResponse(
            IEnumerable<int> succesfullSequences,
            IEnumerable<int> failedSequences)
        {
            SuccesfullSequences = succesfullSequences;
            FailedSequences = failedSequences;
        }
        public string Message => $"Success:{SuccesfullSequences.Count()} Failed:{FailedSequences.Count()}";
        public override string? ToString()
         => Message;
    }
    public enum AssignTraderStatus
    {
        FullSuccess, PartialSuccess, Failure, Unknown
    }
}
