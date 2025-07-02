using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Execution.Api.Events.In;
using Quantaventis.Trading.Modules.Execution.Api.Services;
namespace Quantaventis.Trading.Modules.Execution.Api.Events.Handlers
{
    internal class EmsxOrderCreatedHandler : IEventHandler<EmsxOrderCreated>
    {

        private ILogger<EmsxOrderCreatedHandler> Logger { get; }
        private IEmsxOrderService EmsxOrderService { get; }

        public EmsxOrderCreatedHandler(IEmsxOrderService emsxOrderService, ILogger<EmsxOrderCreatedHandler> logger)
        {
            Logger = logger;
            EmsxOrderService = emsxOrderService;
        }

        public async Task HandleAsync(EmsxOrderCreated @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"{@event} received..");
           await EmsxOrderService.OnEmsxOrderCreatedAsync(@event.EmsxOrder);
        }

    }

}
