using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.In
{
    internal record EmsxRebalCancellationSent(int RebalancingSessionId,IEnumerable<string> OrderRefId) : IEvent
    {
    }
}
