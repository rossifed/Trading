using Quantaventis.Trading.Modules.Trades.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Trades.Api.Events.In
{
    internal record EmsxOrdersSyncEvent(IEnumerable<EmsxOrderDto> EmsxOrders, DateTime TimeStampUtc) : IEvent
    {
    }
}
