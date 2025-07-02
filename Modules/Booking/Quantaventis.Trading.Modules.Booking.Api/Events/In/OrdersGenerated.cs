using Quantaventis.Trading.Modules.Booking.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Booking.Api.Events.In
{
    internal record OrdersGenerated(int RebalancingSessionId, 
        DateOnly TradeDate, 
        string TradeMode, 
        string ExecutionChannel, 
        IEnumerable<OrderDto> Orders) : IEvent
    {
    }
}
