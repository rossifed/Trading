using Quantaventis.Trading.Modules.Valuation.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Valuation.Api.Events.In
{
    public record PortfolioCreated(PortfolioDto Portfolio) : IEvent
    {
    }
}
