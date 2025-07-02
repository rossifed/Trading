using Quantaventis.Trading.Modules.Execution.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.EMSX.Api.Events.Out
{
    internal record EmsxRouteUpdated(EmsxRouteDto EmsxRoute): IEvent;
   
}
