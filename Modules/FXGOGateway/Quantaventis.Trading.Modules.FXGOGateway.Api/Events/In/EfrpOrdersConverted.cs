using Quantaventis.Trading.Modules.FXGOGateway.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.Events.In
{
    internal record EfrpOrdersConverted(IEnumerable<EfrpOrderDto> EfrpOrders) : IEvent;

}
