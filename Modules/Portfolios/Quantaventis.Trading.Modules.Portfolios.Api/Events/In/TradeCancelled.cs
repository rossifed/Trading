using Quantaventis.Trading.Modules.Portfolios.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Portfolios.Api.Events.In
{
    internal record TradeCancelled(BookedTradeDto Trade) : IEvent
    {
    }
}
