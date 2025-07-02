using Quantaventis.Trading.Modules.Execution.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Execution.Api.Events.In
{
    internal record EmsxOrderUpdated(EmsxOrderDto EmsxOrder): IEvent;
   
}
