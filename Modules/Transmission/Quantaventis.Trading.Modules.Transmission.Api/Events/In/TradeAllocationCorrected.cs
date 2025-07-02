using Quantaventis.Trading.Modules.Transmission.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Transmission.Api.Events.Out
{
    internal record TradeAllocationCorrected(BookedTradeAllocationDto TradeAllocation) : IEvent
    {
    }
}
