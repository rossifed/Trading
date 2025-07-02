using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.Out
{
    internal record CancelRebalancingTriggered(int RebalancingSessionId) : IEvent
    {
    }
}
