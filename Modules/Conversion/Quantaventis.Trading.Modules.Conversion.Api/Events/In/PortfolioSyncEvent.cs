using Quantaventis.Trading.Modules.Conversion.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Conversion.Api.Events.In
{
    public record PortfolioSyncEvent(IEnumerable<PortfolioDto> Portfolios) : IEvent
    {
    }
}
