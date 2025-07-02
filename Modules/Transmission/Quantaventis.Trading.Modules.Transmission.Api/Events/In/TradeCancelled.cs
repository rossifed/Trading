using Quantaventis.Trading.Modules.Transmission.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Booking.Api.Events.Out
{
    internal record TradeCancelled(BookedTradeDto Trade) : IEvent
    {
    }
}
