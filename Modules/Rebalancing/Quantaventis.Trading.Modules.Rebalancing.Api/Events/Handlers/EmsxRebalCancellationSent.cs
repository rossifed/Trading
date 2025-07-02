using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.In;
namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.Handlers
{
    internal class EmsxRebalCancellationSentHandler : IEventHandler<EmsxRebalCancellationSent>
    {
        private ILogger<EmsxRebalCancellationSentHandler> Logger { get; }
   
        private IRebalancingService RebalancingService { get; }

        public EmsxRebalCancellationSentHandler(
            IRebalancingService rebalancingService,
            ILogger<EmsxRebalCancellationSentHandler> logger)
        {

            Logger = logger; 
            this.RebalancingService = rebalancingService;
        }
    
        public async Task HandleAsync(EmsxRebalCancellationSent @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event received {@event}..");
            await RebalancingService.ConfirmRebalancingCancelled(@event.RebalancingSessionId);
        }
    }
}
