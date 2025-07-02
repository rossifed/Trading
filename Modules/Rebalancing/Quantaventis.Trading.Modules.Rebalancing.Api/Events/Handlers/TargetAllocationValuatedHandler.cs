using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.In;
using Quantaventis.Trading.Modules.Rebalancing.Api.Mappers;
using Quantaventis.Trading.Modules.Rebalancing.Api.Services;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.Handlers
{
    internal class TargetAllocationValuatedHandler : IEventHandler<TargetAllocationValuated>
    {

        private ILogger<TargetAllocationValuatedHandler> Logger { get; }
   
        private IPortfolioDriftService PortfolioDriftService { get; }

        public TargetAllocationValuatedHandler(
            IPortfolioDriftService portfolioDriftService,
            ILogger<TargetAllocationValuatedHandler> logger)
        {

            Logger = logger; 
            this.PortfolioDriftService = portfolioDriftService;
        }

    
        public async Task HandleAsync(TargetAllocationValuated @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received..");
            var dto = @event.TargetAllocationValuation;
            var targetAllocationValuation = dto.Map();
            await PortfolioDriftService.OnTargetAllocationValuated(targetAllocationValuation);
        }
    }
}
