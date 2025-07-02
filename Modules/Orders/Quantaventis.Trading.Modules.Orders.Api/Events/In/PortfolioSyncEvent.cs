using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Orders.Api.Events.In
{
    public record PortfolioSyncEvent(IEnumerable<PortfolioDto> Portfolios) : IEvent
    {
    }
}
