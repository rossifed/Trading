using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.Out;
using Quantaventis.Trading.Modules.Portfolios.Api.Mappers;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Portfolios.Api.Commands.Handlers
{
    internal class TriggerPortfolioSyncEventHandler : ICommandHandler<TriggerPortfolioSyncEvent>
    {

        private IMessageBroker MessageBroker { get; }


        private IPortfolioDao PortfolioDao { get; }

        private ILogger<TriggerPortfolioSyncEventHandler> Logger { get; }

        public TriggerPortfolioSyncEventHandler(
            IPortfolioDao portfolioDao,

            IMessageBroker messageBroker,
            ILogger<TriggerPortfolioSyncEventHandler> logger)
        {
            this.PortfolioDao = portfolioDao;

            this.MessageBroker = messageBroker;
            this.Logger = logger;

        }


        public async Task HandleAsync(TriggerPortfolioSyncEvent command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received..");
            IEnumerable<Portfolio> portfolios = await PortfolioDao.GetAllAsync();
            var portfolioDto = portfolios.Map();
            await MessageBroker.PublishAsync(new PortfolioSyncEvent(portfolioDto));
        }

    }

}
