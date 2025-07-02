using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Risk.Api.Events.In;
using Quantaventis.Trading.Modules.Risk.Api.Mappers;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Risk.Api.Events.Handlers
{
    internal class PortfolioSyncEventHandler : IEventHandler<PortfolioSyncEvent>
    {
        private IPortfolioDao PortfolioDao { get; }

        private ILogger<PortfolioSyncEventHandler> Logger { get; }
        public PortfolioSyncEventHandler(
            IPortfolioDao portfolioDao,
            ILogger<PortfolioSyncEventHandler> logger)
        {
            this.PortfolioDao = portfolioDao;

            this.Logger = logger;

        }
        public async Task HandleAsync(PortfolioSyncEvent @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received...");
            var entities = @event.Portfolios.Map();
            await PortfolioDao.ReplaceAsync(entities);

        }
    }
}
