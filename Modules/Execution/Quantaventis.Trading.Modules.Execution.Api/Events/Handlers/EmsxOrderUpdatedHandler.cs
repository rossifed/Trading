using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Execution.Api.Events.In;
using Quantaventis.Trading.Modules.Execution.Api.Services;
namespace Quantaventis.Trading.Modules.Execution.Api.Events.Handlers
{
    internal class EmsxOrderUpdatedHandler : IEventHandler<EmsxOrderUpdated>
    {

        private ILogger<EmsxOrderUpdatedHandler> Logger { get; }
        private IEmsxOrderService EmsxOrderService { get; }

        public EmsxOrderUpdatedHandler(IEmsxOrderService emsxOrderService, ILogger<EmsxOrderUpdatedHandler> logger)
        {
            Logger = logger;
            EmsxOrderService = emsxOrderService;
        }


        public async Task HandleAsync(EmsxOrderUpdated @event, CancellationToken cancellationToken = default)
        {

           await EmsxOrderService.OnEmsxOrderUpdatedAsync(@event.EmsxOrder);
        }

    }

}
