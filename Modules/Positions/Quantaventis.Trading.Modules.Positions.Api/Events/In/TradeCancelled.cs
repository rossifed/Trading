using Quantaventis.Trading.Modules.Positions.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Positions.Api.Events.In
{
    internal record TradeCancelled(BookedTradeDto Trade) : IEvent
    {
    }
}
