using Quantaventis.Trading.Modules.Rebalancing.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.In
{
    internal record PortfolioValuated(PortfolioValuationDto PortfolioValuation) : IEvent
    {
    }
}
