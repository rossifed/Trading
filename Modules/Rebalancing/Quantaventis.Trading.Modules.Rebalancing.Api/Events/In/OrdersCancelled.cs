using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.In
{
    internal record OrdersCancelled(int RebalancingSessionId) : IEvent
    {
    }
}
