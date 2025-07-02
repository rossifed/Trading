using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Valuation.Api.Events.In;
using Quantaventis.Trading.Modules.Valuation.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Valuation.Api.Events.Handlers
{
    internal class PositionsUpdatedHandler : IEventHandler<PositionsUpdated>
    {
        private IPortfolioValuationService PortfolioValuationService { get; }
       
        private ILogger<PositionsUpdatedHandler> Logger { get; }
        public PositionsUpdatedHandler(IPortfolioValuationService portfolioValuationService,
            IMessageBroker messageBroker,
            ILogger<PositionsUpdatedHandler> logger) { 
            this.PortfolioValuationService = portfolioValuationService;
            this.Logger = logger;
     

        
        }
        public async Task HandleAsync(PositionsUpdated @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received...");
            await PortfolioValuationService.ValuateAllPortfolioAync();
        }
    }
}
