using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.In;
using Quantaventis.Trading.Modules.Rebalancing.Api.Mappers;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.Handlers
{
    internal class PortfolioCreatedHandler : IEventHandler<PortfolioCreated>
    {

        private IPortfolioDao PortfolioDao { get; }
        private ILogger<PortfolioCreatedHandler> Logger { get; }
        public PortfolioCreatedHandler(
            IPortfolioDao portfolioDao,
            ILogger<PortfolioCreatedHandler> logger) { 
            this.PortfolioDao = portfolioDao;
            this.Logger = logger;    
        }
        public async Task HandleAsync(PortfolioCreated @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received..");
            var entity = @event.Portfolio.Map();
            await PortfolioDao.CreateAsync(entity);
     
        }
    }
}
