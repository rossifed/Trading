using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Events.In
{
    internal record OrdersRoutingRequested(string TradeMode,
        string ExecutionChannel, IEnumerable<OrderRouteDto> Routes) : IEvent
    {
    }
}
