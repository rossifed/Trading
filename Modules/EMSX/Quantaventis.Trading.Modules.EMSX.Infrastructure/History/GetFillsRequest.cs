using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses.Parsers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses.Handlers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{

    internal class GetFillsRequest : AbstractHistoryRequest<GetFillsResponse>, IHistoryRequest<GetFillsResponse>
    {
        internal DateTime FromDateTime { get; }
        internal DateTime ToDateTime { get; }
        internal Scope Scope { get; }
        internal Filter? Filter { get; }
        public GetFillsRequest(
            DateTime fromDateTime,
            DateTime toDateTime,
            Scope scope,
            Filter? filter) : base("GetFills")
        {
            FromDateTime = fromDateTime;
            ToDateTime = toDateTime;
            Scope = scope;
            Filter = filter;
        }
        public GetFillsRequest(
          DateTime fromDateTime,
          DateTime toDateTime,
          Scope scope) : this(
              fromDateTime,
              toDateTime,
              scope,
              null)
        {

        }
        public override IHistoryResponseHandler CreateResponseHandler(TaskCompletionSource<HistoryResponse<GetFillsResponse>> taskCompletionSource)
        {
            return new HistoryResponseHandler<GetFillsRequest, GetFillsResponse>(
                "GetFillsResponse",
                RequestId,
                new GetFillsResponseParser(),
                taskCompletionSource);
        }
        public GetFillsRequest ForDate(
            DateOnly date,
            Scope scope,
            Filter? filter = null)
        {
            return new GetFillsRequest(
                date.ToDateTime(TimeOnly.MinValue),
                date.ToDateTime(TimeOnly.MaxValue),
                scope,
                filter);
        }




        protected override Request BuildRequest(Request request)
        {
            request.Set("FromDateTime", FromDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz"));
            request.Set("ToDateTime", ToDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz"));
            Scope.SetScope(request);
            if (Filter != null) {
                Filter.SetFilter(request);
            }
            return request;
        }
    }
}
