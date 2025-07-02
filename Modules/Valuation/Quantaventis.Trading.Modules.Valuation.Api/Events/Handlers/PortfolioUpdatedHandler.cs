using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Valuation.Api.Events.In;
using Quantaventis.Trading.Modules.Valuation.Api.Mappers;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Valuation.Api.Events.Handlers
{
    internal class PortfolioUpdatedHandler : IEventHandler<PortfolioUpdated>
    {
        private IPortfolioDao PortfolioDao { get; }

        private ILogger<PortfolioUpdatedHandler> Logger { get; }
        public PortfolioUpdatedHandler(
            IPortfolioDao portfolioDao,
            ILogger<PortfolioUpdatedHandler> logger)
        {
            this.PortfolioDao = portfolioDao;

            this.Logger = logger;

        }
        public async Task HandleAsync(PortfolioUpdated @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received...");
            var entity = @event.Portfolio.Map();
            await PortfolioDao.UpdateAsync(entity);

        }
    }
}
