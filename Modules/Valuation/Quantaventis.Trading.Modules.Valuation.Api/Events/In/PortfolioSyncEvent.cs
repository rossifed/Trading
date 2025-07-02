using Quantaventis.Trading.Modules.Valuation.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Valuation.Api.Events.In
{
    public record PortfolioSyncEvent(IEnumerable<PortfolioDto> Portfolios) : IEvent
    {
    }
}
