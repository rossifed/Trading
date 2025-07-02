using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Modules.Execution.Api.Events.In;
using Quantaventis.Trading.Modules.Execution.Api.Services;
using Quartz.Logging;
namespace Quantaventis.Trading.Modules.Execution.Api.Events.Handlers
{
    internal class EmsxFillsFetchedHandler : IEventHandler<EmsxFillsFetched>
    {
        private ILogger<EmsxFillsFetchedHandler> Logger { get; }
        private IEmsxOrderExecutionService EmsxOrderExecutionService { get; }
        public EmsxFillsFetchedHandler(
            IEmsxOrderExecutionService emsxOrderExecutionService,
            ILogger<EmsxFillsFetchedHandler> logger)
        {
            EmsxOrderExecutionService = emsxOrderExecutionService;
            this.Logger = logger;

        }


        public async Task HandleAsync(EmsxFillsFetched @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received..");
           await EmsxOrderExecutionService.OnEmsxFillsReceived(@event.OrderId,@event.EmsxFills);
        }

    }

}
