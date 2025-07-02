using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Events.In
{
    internal record RollOrdersGenerated(
        DateOnly TradeDate, 
        string TradeMode, 
        string ExecutionChannel, 
        IEnumerable<OrderDto> Orders) : IEvent
    {
    }
}
