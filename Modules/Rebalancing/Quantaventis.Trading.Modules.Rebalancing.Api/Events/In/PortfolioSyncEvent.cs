using Quantaventis.Trading.Modules.Rebalancing.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.In
{
    public record PortfolioSyncEvent(IEnumerable<PortfolioDto> Portfolios) : IEvent
    {
    }
}
