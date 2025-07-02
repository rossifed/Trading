using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.In
{
    internal record RiskPreTradeChecked(int RebalancingSessionId, bool IsBreach) : IEvent
    {
    }
}
