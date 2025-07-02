using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Orders.Api.Events.Out
{
    internal record PositionRolloversGenerated(IEnumerable<PositionRolloverDto> PositionRollovers) : IEvent
    {
    }
}
