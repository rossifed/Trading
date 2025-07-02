using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.In;
using Quantaventis.Trading.Modules.Rebalancing.Api.Mappers;
using Quantaventis.Trading.Modules.Rebalancing.Api.Services;

using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.Handlers
{
    internal class PortfolioValuatedHandler : IEventHandler<PortfolioValuated>
    {
        private IPortfolioDriftService PortfolioDriftService { get; }

        private ILogger<PortfolioValuatedHandler> Logger { get; }

        public PortfolioValuatedHandler(
            IPortfolioDriftService portfolioDriftService,        
            ILogger<PortfolioValuatedHandler> logger)
        {

            Logger = logger;           
            this.PortfolioDriftService = portfolioDriftService;
        }


        public async Task HandleAsync(PortfolioValuated @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received..");
            var dto = @event.PortfolioValuation;
            var portfolioValuation = dto.Map();
            await PortfolioDriftService.OnPortfolioValuated(portfolioValuation);


        }
    }
}
